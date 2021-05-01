// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithDeferrerAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso
    ///     cref="IBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnNotifyProperyChangedAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="IBuilderOnValueChanged{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnValueChangedAndDeferrerAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithDeferrerAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithDeferrerAndScheduler<TResult> IObserverBuilderBase<IBuilderWithDeferrerAndScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        INotifyValuePropertyObserverWithDeferrer<TResult> IBuilderWithDeferrerAndScheduler<TResult>.Build() =>
            this.CreateNotifyValuePropertyObserverWithDeferrer();
    }
}