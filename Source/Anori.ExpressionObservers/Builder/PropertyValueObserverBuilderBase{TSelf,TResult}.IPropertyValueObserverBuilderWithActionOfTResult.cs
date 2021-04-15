// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTResult.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

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
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithActionOfTResult<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TResult> IPropertyObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionOfTResult<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResult<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetter<TResult>
            IPropertyValueObserverBuilderWithActionOfTResult<TResult>.WithGetter() =>
            this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<
                IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<
                IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);
    }
}