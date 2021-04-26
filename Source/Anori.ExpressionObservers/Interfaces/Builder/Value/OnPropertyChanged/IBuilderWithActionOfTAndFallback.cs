// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    /// The I Builder With Action Of T And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndFallback{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverScheduler{Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallback<TResult>>,
        IPropertyObserverScheduler<
            IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> WithGetter();
    }
}