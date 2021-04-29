// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    internal abstract partial class
     BuilderBase<TSelf, TResult> : IBuilderWithActionAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value2 Observer Builder.
        /// </returns>
        IBuilderWithActionAndScheduler<TResult> IObserverBuilderBase<IBuilderWithActionAndScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        INotifyReferencePropertyObserver<TResult> IBuilderWithActionAndScheduler<TResult>
            .Build() =>
            this.CreateNotifyReferencePropertyObserverWithAction();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndFallbackAndScheduler<TResult>
            IBuilderWithActionAndScheduler<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);
    }
}