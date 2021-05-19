// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndDeferrer<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndDeferrer<TResult> IObserverBuilderBase<IBuilderWithActionOfTAndDeferrer<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> IBuilderWithActionOfTAndDeferrer<TResult>.WithFallback(
            TResult fallback) =>
            this.WithFallback(fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionOfTAndGetterAndDeferrer<TResult> IBuilderWithActionOfTAndDeferrer<TResult>.WithGetter() =>
            this;
    }
}