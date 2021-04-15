// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    /// The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Builder.PropertyObserverBuilderBase{TSelf}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilder{TResult}" />
    // ReSharper disable UnusedTypeParameter
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithAction<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithAction<TResult> IPropertyObserverBuilderBase<
            IPropertyValueObserverBuilderWithAction<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TResult> IPropertyValueObserverBuilderWithAction<TResult>.Build() =>
            this.CreatePropertyObserver();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TResult> IPropertyValueObserverBuilderWithAction<TResult>.
            WithGetter() =>
            this;
    }
}