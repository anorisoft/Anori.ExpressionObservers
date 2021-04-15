// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    /// The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyReferenceObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithValueChanged{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilder{TResult}" />
    internal abstract partial class
        PropertyReferenceObserverBuilderBase<TSelf, TResult> :
            IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> IPropertyObserverBuilderBase<
            IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Cached(
                LazyThreadSafetyMode safetyMode)
        {
            return this.Cached(safetyMode);
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Cached()
        {
            return this.Cached();
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyReferenceObserverOnValueChanged<TResult>
            IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Build() =>
            this.CreatePropertyReferenceObserverBuilderWithValueChanged();
    }
}