// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilder{TResult}" />
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithActionAndGetter<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TResult> IPropertyObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionAndGetter<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserverWithGetter<TResult> IPropertyValueObserverBuilderWithActionAndGetter<TResult>.Build() =>
            this.CreatePropertyValueObserverWithGetter();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionAndGetter<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult> IPropertyObserverGetterTaskScheduler<
            IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>>
            .WithGetterTaskScheduler(TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);
    }
}