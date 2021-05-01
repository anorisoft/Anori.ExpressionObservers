// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The I Property Value Observer Builder With Action Of T Result And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndScheduler<TResult> WithFallback(TResult fallback);
    }
}