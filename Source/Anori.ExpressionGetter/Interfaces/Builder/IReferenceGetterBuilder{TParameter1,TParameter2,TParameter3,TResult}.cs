// -----------------------------------------------------------------------
// <copyright file="IReferenceGetterBuilder{TParameter1,TParameter2,TParameter3,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The Reference Getter Builder interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IReferenceGetterBuilder<in TParameter1, in TParameter2, in TParameter3, TResult>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance of a getter function.
        /// </summary>
        /// <returns>The getter function.</returns>
        Func<TParameter1, TParameter2, TParameter3, TResult?> Build();

        /// <summary>
        ///     Getter Builder with Fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Getter Builder with Fallback.</returns>
        IGetterBuilderWithFallback<TParameter1, TParameter2, TParameter3, TResult> WithFallback(TResult fallback);
    }
}