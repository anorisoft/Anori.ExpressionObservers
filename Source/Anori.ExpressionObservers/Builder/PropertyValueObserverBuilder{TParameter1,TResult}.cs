// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilder{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.ValueTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TParameter1, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TParameter1, TResult}" />
    public class PropertyValueObserverBuilder<TParameter1, TResult> :
        IPropertyValueObserverBuilder<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithAction<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        ///     The parameter1.
        /// </summary>
        private readonly TParameter1 parameter1;

        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> propertyExpression;

        /// <summary>
        ///     The action.
        /// </summary>
        private Action? action;

        /// <summary>
        ///     The action of t result.
        /// </summary>
        private Action<TResult?>? actionOfTResult;

        /// <summary>
        /// The fallback.
        /// </summary>
        private TResult fallback;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverBuilder{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public PropertyValueObserverBuilder(
            TParameter1 parameter1,
            Expression<Func<TParameter1, TResult>> propertyExpression)
        {
            this.parameter1 = parameter1;
            this.propertyExpression = propertyExpression;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueGetterObserver<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>.Create()
        {
            return new PropertyValueGetterObserver<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.actionOfTResult!);
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserverWithGetter<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>.Create()
        {
            return new PropertyValueObserverWithGetter<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.action!);
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TParameter1, TResult> IPropertyValueObserverBuilderWithAction<TParameter1, TResult>.
            Create() =>
            new PropertyObserver<TParameter1, TResult>(this.parameter1, this.propertyExpression, this.action!);

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyObserverWithGetterAndFallback<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>.Create()
        {
            return new PropertyObserverWithGetterAndFallback<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.action!,
                this.fallback);
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>
            IPropertyValueObserverBuilder<TParameter1, TResult>.WithAction(Action<TResult?> action)
        {
            this.actionOfTResult = action;
            return this;
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithAction<TParameter1, TResult>
            IPropertyValueObserverBuilder<TParameter1, TResult>.WithAction(Action action)
        {
            this.action = action;
            return this;
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>.WithFallback(TResult fallback)
        {
            this.fallback = fallback;
            return this;
        }

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>
            IPropertyValueObserverBuilderWithAction<TParameter1, TResult>.WithGetter() =>
            this;
    }
}