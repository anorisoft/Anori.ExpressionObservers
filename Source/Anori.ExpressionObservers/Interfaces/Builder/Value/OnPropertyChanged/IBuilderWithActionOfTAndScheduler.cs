// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The Property Value Observer Builder With Action Of T Result And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> WithGetter();
    }
}