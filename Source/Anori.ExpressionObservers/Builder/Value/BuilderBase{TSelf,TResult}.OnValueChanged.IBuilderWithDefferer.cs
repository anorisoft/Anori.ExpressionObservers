// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithDefferer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Value
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged;

    /// <summary>
    ///     The value property observer builder base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithDeferrer<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     value property observer On Notify Property Changed.
        /// </returns>
        INotifyValuePropertyObserverWithDeferrer<TResult> IBuilderWithDeferrer<TResult>.Build() =>
            this.CreateNotifyValuePropertyObserverWithDeferrer();
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithDeferrer<TResult> IObserverBuilderBase<IBuilderWithDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();
    }
}