// -----------------------------------------------------------------------
// <copyright file="SyncronisationContextExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Threading;

    using Anori.ExpressionObservers.ValueTypeObservers;

    /// <summary>
    ///     The Syncronisation Context Extensions class.
    /// </summary>
    public static class SyncronisationContextExtensions
    {
        /// <summary>
        /// Sends the specified function.
        /// </summary>
        /// <typeparam name="TArg1">The type of the arg1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="func">The function.</param>
        /// <param name="arg1">The arg1.</param>
        /// <returns>The result.</returns>
        public static TResult Send<TArg1, TResult>(
            this SynchronizationContext synchronizationContext,
            Func<TArg1, TResult> func,
            TArg1 arg1)
        {
            SendFuncState<TArg1, TResult> state = new SendFuncState<TArg1, TResult> { Func = func, Arg1 = arg1 };

            static void SendOrPostCallback(object obj)
            {
                var s = (SendFuncState<TArg1, TResult>)obj;
                s.Result = s.Func(s.Arg1);
            }

            synchronizationContext.Send(SendOrPostCallback, state);
            return state.Result;
        }

        /// <summary>
        /// Sends the specified function.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="func">The function.</param>
        /// <returns>The result.</returns>
        public static TResult Send<TResult>(this SynchronizationContext synchronizationContext, Func<TResult> func)
        {
            SendFuncState<TResult> state = new SendFuncState<TResult> { Func = func };

            static void SendOrPostCallback(object obj)
            {
                var s = (SendFuncState<TResult>)obj;
                s.Result = s.Func();
            }

            synchronizationContext.Send(SendOrPostCallback, state);
            return state.Result;
        }
    }
}