// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderOnNotifyProperyChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnNotifyProperyChangedAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilderOnValueChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilder<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilder<TResult>
            IObserverBuilderBase<IBuilder<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IGetterValuePropertyObserver<TResult>
            IBuilder<TResult>.Build() =>
            this.CreateGetterValuePropertyObserver();

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilder<TResult>
            IBuilder<TResult>.Cached() =>
            this.Cached();

        /// <summary>
        /// Defers this instance.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IBuilderWithDeferrer<TResult> IBuilder<TResult>.Deferred() => this;

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilder<TResult>
            IBuilder<TResult>.Cached(
                LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<
                IBuilderWithScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<
                IBuilderWithScheduler<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}