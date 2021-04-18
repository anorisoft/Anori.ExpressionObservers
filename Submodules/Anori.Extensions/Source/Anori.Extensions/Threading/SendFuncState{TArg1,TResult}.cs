// -----------------------------------------------------------------------
// <copyright file="SendFuncState{TArg1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.Threading
{
    using System;

    /// <summary>
    ///     The Send Function State class.
    /// </summary>
    /// <typeparam name="TArg1">The type of the arg1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class SendFuncState<TArg1, TResult>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SendFuncState{TArg1, TResult}" /> class.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <param name="arg1">The arg1.</param>
        public SendFuncState(Func<TArg1, TResult> func, TArg1 arg1)
        {
            this.Func = func;
            this.Arg1 = arg1;
        }

        /// <summary>
        ///     Gets the function.
        /// </summary>
        /// <value>
        ///     The function.
        /// </value>
        public Func<TArg1, TResult> Func { get; }

        /// <summary>
        ///     Gets the result.
        /// </summary>
        /// <value>
        ///     The result.
        /// </value>
        public TResult? Result { get; private set; }

        /// <summary>
        ///     Gets the arg1.
        /// </summary>
        /// <value>
        ///     The arg1.
        /// </value>
        public TArg1 Arg1 { get; }

        /// <summary>
        ///     Excecutes this instance.
        /// </summary>
        public void Excecute() => this.Result = this.Func(this.Arg1);
    }
}