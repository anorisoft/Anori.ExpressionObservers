// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithValueChangedAndDefferer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Builder.PropertyObserverBuilderBase{TSelf}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilder{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndDeferrer{TResult}" />
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithValueChangedAndDeferrer<
            TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        public IPropertyValueObserverOnValueChangedWithDeferrer<TResult> Build() =>
            this.CreatePropertyValueObserverBuilderWithValueChangedAndDeferrer();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndDeferrer<TResult> IPropertyObserverBuilderBase<
            IPropertyValueObserverBuilderWithValueChangedAndDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Deferred() =>
            this;
    }
}