// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    /// The I Builder With Action Of T And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfTAndDeferrer{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderSchedulerBase{Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfTAndDeferrer{TResult}}" />
    public interface IBuilderWithActionOfTAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndDeferrer<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);

    }
}