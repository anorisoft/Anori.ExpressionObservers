// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The builder with action of T and deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface
        IBuilderWithActionOfTAndDeferrer<TResult> : IObserverBuilderBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Builder with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>The getter.</returns>
        IBuilderWithActionOfTAndGetterAndDeferrer<TResult> WithGetter();
    }
}