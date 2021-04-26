// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;
    using System.Threading.Tasks;

    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndGetterAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndScheduler<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>
            IBuilderWithActionOfTAndGetterAndScheduler<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);
    }
}