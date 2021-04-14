// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTResultAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using System.Threading.Tasks;

    /// <summary>
    /// The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilder{TResult}" />
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallback<
            TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallback<TResult>.Build() =>
            this.CreatePropertyObserverWithActionOfTResultAndGetterAndFallback();

        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        /// The target object.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<TResult> IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<TResult>>.WithGetterTaskScheduler(
            TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this;
        }

        /// <summary>
        /// Withes the getter dispatcher.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<TResult> IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this;
        }

        /// <summary>
        /// Automatics the activate.
        /// </summary>
        /// <returns>
        /// The Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallback<TResult>
            IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();
    }
}