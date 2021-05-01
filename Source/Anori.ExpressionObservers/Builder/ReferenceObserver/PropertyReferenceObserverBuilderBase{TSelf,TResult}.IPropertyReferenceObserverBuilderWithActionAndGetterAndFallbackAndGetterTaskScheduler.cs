// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    internal abstract partial class BuilderBase<TSelf, TResult> :
        IBuilderWithActionAndGetterAndFallbackAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallbackAndScheduler<TResult>
            IObserverBuilderBase<
                IBuilderWithActionAndGetterAndFallbackAndScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        ///// <summary>
        /////     Creates this instance.
        ///// </summary>
        ///// <returns>
        /////     Property Observer With Getter And Fallback.
        ///// </returns>
        //IPropertyObserverWithGetterAndFallback<TResult>
        //    IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndScheduler<TResult>.Build() =>
        //    this.CreateGetterPropertyObserverWithActionAndGetterAndFallback();
        IGetterPropertyObserver<TResult> IBuilderWithActionAndGetterAndFallbackAndScheduler<TResult>.Build()
        {
            return this.CreatePropertyObserverWithGetterAndFallback();
        }
    }
}