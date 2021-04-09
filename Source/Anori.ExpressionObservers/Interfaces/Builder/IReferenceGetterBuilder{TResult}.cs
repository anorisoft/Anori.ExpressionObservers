// -----------------------------------------------------------------------
// <copyright file="IReferenceGetterBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System;

    /// <summary>
    /// The Reference Getter Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IReferenceGetterBuilder<out TResult>
        where TResult : class
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The Getter.</returns>
        Func<TResult?> Build();
    }
}