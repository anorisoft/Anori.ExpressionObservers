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

    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The property observer builder class.
    /// </summary>
    /// <seealso cref="IPropertyObserverBuilder" />
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
        ///     The observer flag.
        /// </summary>
        private readonly PropertyObserverFlag observerFlag;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBuilder" /> class.
        /// </summary>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        /// <param name="autoActivate">if set to <c>true</c> [automatic activate].</param>
        /// <param name="silentActivate">if set to <c>true</c> [silent activate].</param>
        public PropertyObserverBuilder(
            PropertyObserverFlag propertyObserverFlag = PropertyObserverFlag.None,
            bool autoActivate = false,
            bool silentActivate = true)
        {
            this.observerFlag = propertyObserverFlag;
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
        ///     References the observer builder.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     Reference property observer builder.
        /// </returns>
        public IReferenceObserverBuilder<TResult> ReferenceObserverBuilder<TParameter1, TResult>(
            TParameter1 parameter1,
            Expression<Func<TParameter1, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TResult : class
        {
            var builder = new Reference.Builder<TParameter1, TResult>(parameter1, propertyExpression)
                              {
                                  ObserverFlag = this.observerFlag,
                                  IsAutoActivate = this.isAutoActivate,
                                  IsSilentActivate = this.isSilentActivate,
                              };
            return builder;
        }

        /// <summary>
        ///     References the observer builder.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     Reference property observer builder.
        /// </returns>
        public IReferenceObserverBuilder<TResult> ReferenceObserverBuilder<TResult>(
            Expression<Func<TResult>> propertyExpression)
            where TResult : class
        {
            var builder = new Reference.Builder<TResult>(propertyExpression)
                              {
                                  ObserverFlag = this.observerFlag,
                                  IsAutoActivate = this.isAutoActivate,
                                  IsSilentActivate = this.isSilentActivate,
                              };
            return builder;
        }

        /// <summary>
        ///     References the observer builder.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     Reference property observer builder.
        /// </returns>
        public IReferenceObserverBuilder<TResult> ReferenceObserverBuilder<TParameter1, TParameter2, TResult>(
            TParameter1 parameter1,
            TParameter2 parameter2,
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class
        {
            var builder =
                new Reference.Builder<TParameter1, TParameter2, TResult>(parameter1, parameter2, propertyExpression)
                    {
                        ObserverFlag = this.observerFlag,
                        IsAutoActivate = this.isAutoActivate,
                        IsSilentActivate = this.isSilentActivate,
                    };
            return builder;
        }

        /// <summary>
        ///     Values the observer builder.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     Value property observer builder.
        /// </returns>
        public IValueObserverBuilder<TResult> ValueObserverBuilder<TParameter1, TResult>(
            TParameter1 parameter1,
            Expression<Func<TParameter1, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var builder = new Value.Builder<TParameter1, TResult>(parameter1, propertyExpression)
                              {
                                  ObserverFlag = this.observerFlag,
                                  IsAutoActivate = this.isAutoActivate,
                                  IsSilentActivate = this.isSilentActivate,
                              };
            return builder;
        }

        /// <summary>
        ///     Values the observer builder.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     Value property observer builder.
        /// </returns>
        public IValueObserverBuilder<TResult> ValueObserverBuilder<TParameter1, TParameter2, TResult>(
            TParameter1 parameter1,
            TParameter2 parameter2,
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : struct
        {
            var builder =
                new Value.Builder<TParameter1, TParameter2, TResult>(parameter1, parameter2, propertyExpression)
                    {
                        ObserverFlag = this.observerFlag,
                        IsAutoActivate = this.isAutoActivate,
                        IsSilentActivate = this.isSilentActivate,
                    };
            return builder;
        }

        /// <summary>
        ///     Values the observer builder.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     Value property observer builder.
        /// </returns>
        public IValueObserverBuilder<TResult> ValueObserverBuilder<TResult>(
            Expression<Func<TResult>> propertyExpression)
            where TResult : struct
        {
            var builder = new Value.Builder<TResult>(propertyExpression)
                              {
                                  ObserverFlag = this.observerFlag,
                                  IsAutoActivate = this.isAutoActivate,
                                  IsSilentActivate = this.isSilentActivate,
                              };
            return builder;
        }
    }
}