// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    internal abstract partial class BuilderBase<TSelf, TResult> :
     IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>
            IObserverBuilderBase<
                IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>
            .AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        IGetterPropertyObserver<TResult>
            IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>.
            Build() =>
            this.CreatePropertyObserverWithActionOfTAndGetterAndFallback();
    }
}