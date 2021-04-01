// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     The Property Observer Builder class.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBuilder" />
    public class PropertyObserverBuilder : IPropertyObserverBuilder
    {
        /// <summary>
        ///     The is automatic activate.
        /// </summary>
        private readonly bool isAutoActivate;

        /// <summary>
        ///     The is silent activate.
        /// </summary>
        private readonly bool isSilentActivate;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBuilder" /> class.
        /// </summary>
        /// <param name="autoActivate">if set to <c>true</c> [automatic activate].</param>
        /// <param name="silentActivate">if set to <c>true</c> [silent activate].</param>
        public PropertyObserverBuilder(bool autoActivate = false, bool silentActivate = true)
        {
            this.isAutoActivate = autoActivate;
            this.isSilentActivate = silentActivate;
        }

        /// <summary>
        ///     Gets the builder.
        /// </summary>
        /// <value>
        ///     The builder.
        /// </value>
        public static IPropertyObserverBuilder Builder { get; } = new PropertyObserverBuilder();

        /// <summary>
        ///     Values the observer builder.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     Value Property Observer Builder.
        /// </returns>
        public IPropertyValueObserverBuilder<TResult> ValueObserverBuilder<TParameter1, TResult>(
            TParameter1 parameter1,
            Expression<Func<TParameter1, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var builder = new PropertyValueObserverBuilder<TParameter1, TResult>(parameter1, propertyExpression)
                              {
                                  IsAutoActivate = this.isAutoActivate, IsSilentActivate = this.isSilentActivate,
                              };
            return builder;
        }
    }
}