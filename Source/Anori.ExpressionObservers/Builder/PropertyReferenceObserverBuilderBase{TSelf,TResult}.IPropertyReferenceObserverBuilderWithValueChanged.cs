// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderWithValueChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Property Reference Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Builder.PropertyObserverBuilderBase{TSelf}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithValueChanged{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithAction{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilder{TResult}" />
    internal abstract partial class
        PropertyReferenceObserverBuilderBase<TSelf, TResult> : IPropertyReferenceObserverBuilderWithValueChanged<TResult
        >
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithValueChanged<TResult> IPropertyObserverBuilderBase<
            IPropertyReferenceObserverBuilderWithValueChanged<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyReferenceObserverOnValueChanged<TResult> IPropertyReferenceObserverBuilderWithValueChanged<TResult>.
            Build() =>
            this.CreatePropertyReferenceObserverBuilderWithValueChanged();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChanged<TResult>
            IPropertyReferenceObserverBuilderWithValueChanged<TResult>.Cached() =>
            this.Cached();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChanged<TResult>
            IPropertyReferenceObserverBuilderWithValueChanged<TResult>.Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndDeferrer<TResult>
            IPropertyReferenceObserverBuilderWithValueChanged<TResult>.Deferred() =>
            this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<
                IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<
                IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);
    }
}