// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithNotifyProperyChanged.cs" company="AnoriSoft">
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
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult
        >

    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>.Cached()
        {
            this.IsCached = true;
            this.SafetyMode = LazyThreadSafetyMode.None;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>.Cached(
                LazyThreadSafetyMode safetyMode)
        {
            this.IsCached = true;
            this.SafetyMode = safetyMode;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.Cached()
        {
            this.IsCached = true;
            this.SafetyMode = LazyThreadSafetyMode.None;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.Cached(LazyThreadSafetyMode safetyMode)
        {
            this.IsCached = true;
            this.SafetyMode = safetyMode;
            return this.Cached();
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.Build() =>
            this.CreatePropertyValueObserverOnNotifyProperyChanged();

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult> IPropertyObserverGetterTaskScheduler<
            IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this;
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this;
        }
    }
}