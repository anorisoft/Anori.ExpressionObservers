// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderOnValueChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged;

    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilder<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value2 Observer Builder.</returns>
        IBuilder<TResult> IObserverBuilderBase<IBuilder<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value2 Observer On Notify Propery Changed.
        /// </returns>
        INotifyValuePropertyObserver<TResult> IBuilder<TResult>.Build() =>
            this.CreateNotifyPropertyObserver();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value2 Observer Builder.
        /// </returns>
        IBuilder<TResult> IBuilder<TResult>.
            Cached() =>
            this.Cached();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value2 Observer Builder.
        /// </returns>
        IBuilder<TResult> IBuilder<TResult>.
            Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value2 Observer Builder.
        /// </returns>
        IBuilderWithDeferrer<TResult> IBuilder<TResult>.Deferred() =>
            this;

        /// <summary>
        /// Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithAction<TResult> IBuilder<TResult>.WithAction(Action action)
        {
            this.ObserverMode = ObserverMode.OnValueCahnged;
            return this.WithAction(action);
        }
        /// <summary>
        /// Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IBuilder<TResult>.WithAction(Action<TResult> action)
        {
            this.ObserverMode = ObserverMode.OnValueCahnged;
            return this.WithActionOfTWithFallback(action);
        }
        /// <summary>
        /// Withes the nullable action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IBuilder<TResult>.WithAction(Action<TResult?> action)
        {
            this.ObserverMode = ObserverMode.OnValueCahnged;
            return this.WithActionOfT(action);
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value2 Observer Builder.
        /// </returns>
        IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<IBuilderWithScheduler<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();
        
        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<IBuilderWithScheduler<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}