﻿// -----------------------------------------------------------------------
// <copyright file="IGetterBuilderWithFallback{TParameter1,TParameter2,TParameter3,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    /// <summary>
    /// The I Getter Builder With Fallback interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IGetterBuilderWithFallback<in TParameter1, in TParameter2, in TParameter3, out TResult>
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The Getter.</returns>
        Func<TParameter1, TParameter2, TParameter3, TResult> Build();
    }
}