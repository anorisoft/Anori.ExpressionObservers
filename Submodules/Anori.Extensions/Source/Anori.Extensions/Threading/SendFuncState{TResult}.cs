// -----------------------------------------------------------------------
// <copyright file="SendFuncState.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.Threading
{
    using System;

    /// <summary>
    /// SendFuncState.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class SendFuncState<TResult>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SendFuncState{TResult}"/> class.
        /// </summary>
        /// <param name="func">The function.</param>
        public SendFuncState(Func<TResult> func) => this.Func = func;

        /// <summary>
        /// Gets the function.
        /// </summary>
        /// <value>
        /// The function.
        /// </value>
        public Func<TResult> Func { get; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public TResult? Result { get; private set; }

        /// <summary>
        /// Excecutes this instance.
        /// </summary>
        public void Excecute() => this.Result = this.Func();

    }
}