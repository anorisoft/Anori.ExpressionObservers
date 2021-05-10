// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionOfTAndDeferrer<TResult> : IObserverBuilderBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The getter.</returns>
        IBuilderWithActionOfTAndGetterAndDeferrer<TResult> WithGetter();
    }
}