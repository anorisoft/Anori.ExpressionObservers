// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Reference
{
    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The value property observer builder base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    // ReSharper disable UnusedTypeParameter
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionAndDeferrer<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IPropertyObserverWithDeferrer<TResult> IBuilderWithActionAndDeferrer<TResult>.Build() =>
            this.CreatePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> IBuilderWithActionAndDeferrer<TResult>.WithGetter() => this;

        /// <summary>
        ///     Builder with cache.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndDeferrer<TResult> ICacheBase<IBuilderWithActionAndDeferrer<TResult>>.WithCache(
            LazyThreadSafetyMode safetyMode) =>
            this.WithCache(safetyMode);

        /// <summary>
        ///     Builder with cache.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndDeferrer<TResult> ICacheBase<IBuilderWithActionAndDeferrer<TResult>>.WithCache() =>
            this.WithCache();
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionAndDeferrer<TResult> IObserverBuilderBase<IBuilderWithActionAndDeferrer<TResult>>.
            AutoActivate() =>
            this.AutoActivate();
    }
}