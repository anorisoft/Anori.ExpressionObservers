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

    using Anori.ExpressionObservers.Interfaces;

    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndFallbackAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndScheduler<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserver<TResult>
            IBuilderWithActionOfTAndFallbackAndScheduler<TResult>.Build() =>
            this.CreatePropertyObserverWithActionOfTAndGetterAndFallbackAndScheduler();
    }
}