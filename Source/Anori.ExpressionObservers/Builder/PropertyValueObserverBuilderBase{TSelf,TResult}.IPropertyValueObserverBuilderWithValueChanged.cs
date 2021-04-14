// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithValueChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithValueChanged<TResult>

    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyObserverBuilderBase<
            IPropertyValueObserverBuilderWithValueChanged<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.
            Cached()
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
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.
            Cached(LazyThreadSafetyMode safetyMode)
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
        IPropertyValueObserverOnValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.Build() =>
            this.CreatePropertyValueObserverBuilderWithValueChanged();

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> IPropertyObserverGetterTaskScheduler<
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.WithGetterDispatcher()
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
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this;
        }
    }
}