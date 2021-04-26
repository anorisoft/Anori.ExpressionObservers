// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionAndGetterAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionAndGetterAndScheduler<TResult> IObserverBuilderBase<IBuilderWithActionAndGetterAndScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterValuePropertyObserver<TResult> IBuilderWithActionAndGetterAndScheduler<TResult>.Build() =>
            this.CreateGetterValuePropertyObserverWithActionAndGetterAndScheduler();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallbackAndScheduler<TResult> IBuilderWithActionAndGetterAndScheduler<TResult>.WithFallback(
            TResult fallback) =>
            this.WithFallback(fallback);
       
    }
}