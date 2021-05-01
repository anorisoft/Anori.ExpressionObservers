// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Builder.PropertyObserver.BuilderBase{TSelf}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetterAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithAction{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithDeferrer{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithAction{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithDeferrerAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetter{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallbackAndDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallbackAndDeferrerAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilder{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallbackAndScheduler{TResult}" />
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithFallbackAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndScheduler<TResult> IObserverBuilderBase<IBuilderWithFallbackAndScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        INotifyPropertyObserver<TResult> IBuilderWithFallbackAndScheduler<TResult>.Build() =>
            this.CreateNotifyPropertyObserverWithFallback();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndScheduler<TResult> IBuilderWithFallbackAndScheduler<TResult>.Cached(
            LazyThreadSafetyMode safetyMode)
        {
            return this.Cached(safetyMode);
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndScheduler<TResult> IBuilderWithFallbackAndScheduler<TResult>.Cached()
        {
            return this.Cached();
        }

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndDeferrerAndScheduler<TResult> IBuilderWithFallbackAndScheduler<TResult>.Deferred() =>
            this;
    }
}