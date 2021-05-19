// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    // ReSharper disable UnusedTypeParameter
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionAndDeferrer<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionAndDeferrer<TResult> IObserverBuilderBase<IBuilderWithActionAndDeferrer<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithDeferrer<TResult> IBuilderWithActionAndDeferrer<TResult>.Build() =>
            this.CreatePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> IBuilderWithActionAndDeferrer<TResult>.WithGetter() => this;

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionAndDeferrer<TResult> ICacheBase<IBuilderWithActionAndDeferrer<TResult>>.Cached(
            LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionAndDeferrer<TResult> ICacheBase<IBuilderWithActionAndDeferrer<TResult>>.Cached() =>
            this.Cached();
    }
}