// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The I value property observer builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfT<TResult> : IObserverBuilderBase<IBuilderWithActionOfT<TResult>>,
                                                      IDeferrerBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionOfTAndFallback<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>The getter.</returns>
        IBuilderWithActionOfTAndGetter<TResult> WithGetter();
    }
}