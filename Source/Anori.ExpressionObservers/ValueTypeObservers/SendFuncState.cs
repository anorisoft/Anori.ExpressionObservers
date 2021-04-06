// -----------------------------------------------------------------------
// <copyright file="SendFuncState.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
{
    using System;

    /// <summary>
    /// The Send Function State class.
    /// </summary>
    /// <typeparam name="TArg1">The type of the arg1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class SendFuncState<TArg1, TResult>
    {
        /// <summary>
        /// Gets or sets the function.
        /// </summary>
        /// <value>
        /// The function.
        /// </value>
        public Func<TArg1, TResult> Func { get; set; }
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public TResult Result { get; set; }
        /// <summary>
        /// Gets or sets the arg1.
        /// </summary>
        /// <value>
        /// The arg1.
        /// </value>
        public TArg1 Arg1 { get; set; }
    }

    /// <summary>
    /// SendFuncState.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class SendFuncState<TResult>
    {
        /// <summary>
        /// Gets or sets the function.
        /// </summary>
        /// <value>
        /// The function.
        /// </value>
        public Func<TResult> Func { get; set; }
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public TResult Result { get; set; }
    }
}