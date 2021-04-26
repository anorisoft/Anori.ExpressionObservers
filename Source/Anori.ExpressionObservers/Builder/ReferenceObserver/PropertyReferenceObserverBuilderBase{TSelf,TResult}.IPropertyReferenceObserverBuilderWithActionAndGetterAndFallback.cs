// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    internal abstract partial class
        BuilderBase<TSelf, TResult> :
            IBuilderWithActionAndGetterAndFallback<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionAndGetterAndFallback<TResult>
            IObserverBuilderBase<IBuilderWithActionAndGetterAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        IGetterPropertyObserver<TResult>
            IBuilderWithActionAndGetterAndFallback<TResult>.Build() =>
            this.CreatePropertyObserverWithGetterAndFallback();

        Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndFallbackAndScheduler<TResult> IPropertyObserverScheduler<Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndFallbackAndScheduler<TResult>>.WithGetterDispatcher()
        {
            return WithGetterDispatcher();
        }

        Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndFallbackAndScheduler<TResult> IPropertyObserverScheduler<Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndFallbackAndScheduler<TResult>>.WithScheduler(
            TaskScheduler taskScheduler)
        {
            return WithScheduler(taskScheduler);
        }
    }
}