// -----------------------------------------------------------------------
// <copyright file="IGetterBuilderWithFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The expression getter builder with fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IGetterBuilderWithFallback<out TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The expression getter.</returns>
        Func<TResult> Build();
    }
}