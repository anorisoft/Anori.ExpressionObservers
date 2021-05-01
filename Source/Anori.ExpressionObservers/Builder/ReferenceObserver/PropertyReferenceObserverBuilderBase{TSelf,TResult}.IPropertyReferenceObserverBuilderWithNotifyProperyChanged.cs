// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnNotifyProperyChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IBuilderOnProperyChanged{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IReferenceObserverBuilder{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilderOnProperyChanged
            <TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderOnProperyChanged<TResult>
            IObserverBuilderBase<IBuilderOnProperyChanged<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        INotifyReferencePropertyObserver<TResult> IBuilderOnProperyChanged<TResult>.Build() =>
            this.CreatePropertyReferenceObserverOnNotifyProperyChanged();

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderOnProperyChanged<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler<TResult>.Cached() =>
            this.Cached();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderOnProperyChanged<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler<TResult>.Cached(
                LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderOnProperyChanged<TResult> IBuilderOnProperyChanged<TResult>.Cached() =>
            this.Cached();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderOnProperyChanged<TResult> IBuilderOnProperyChanged<TResult>.
            Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfT<TResult> IBuilderOnProperyChanged<TResult>.WithAction(Action<TResult> action)
        {
            this.ObserverMode = ObserverMode.OnNotifyPropertyChanged;
            return this.WithActionOfTWithFallback(action);
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction<TResult> IBuilderOnProperyChanged<TResult>.WithAction(Action action)
        {
            this.ObserverMode = ObserverMode.OnNotifyPropertyChanged;
            return this.WithAction(action);
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);

        /// <summary>
        ///     Withes the nullable action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfNullableT<TResult> IBuilderOnProperyChanged<TResult>.WithNullableAction(
                Action<TResult?> action)
        {
            this.ObserverMode = ObserverMode.OnNotifyPropertyChanged;
            return this.WithActionOfT(action);
        }
    }
}