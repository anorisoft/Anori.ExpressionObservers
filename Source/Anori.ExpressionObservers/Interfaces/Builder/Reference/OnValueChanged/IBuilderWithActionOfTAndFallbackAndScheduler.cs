// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The Property Reference Observer Builder With Action Of T Result And Getter And Fallback And Getter Task Scheduler
    ///     interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}}" />
    public interface
        IBuilderWithActionOfTAndFallbackAndScheduler<out TResult> : IObserverBuilderBase<
            IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        INotifyPropertyObserver<TResult> Build();
    }
}