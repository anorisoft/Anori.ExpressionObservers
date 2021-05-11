// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
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
        INotifyPropertyObserverWithDeferrer<TResult> IBuilderWithActionAndDeferrer<TResult>.Build() =>
            this.CreatePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithActionAndGetter<TResult> IBuilderWithActionAndDeferrer<TResult>.WithGetter() => this;
    }
}