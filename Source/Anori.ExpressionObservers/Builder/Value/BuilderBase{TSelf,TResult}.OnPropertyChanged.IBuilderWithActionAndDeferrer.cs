// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Value
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
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
        IBuilderWithActionAndGetter<TResult> IBuilderWithActionAndDeferrer<TResult>.WithGetter() => this;
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionAndDeferrer<TResult> IObserverBuilderBase<IBuilderWithActionAndDeferrer<TResult>>.
            AutoActivate() =>
            this.AutoActivate();
    }
}