// -----------------------------------------------------------------------
// <copyright file="ISchedulerBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System.Threading.Tasks;

    /// <summary>
    ///     The Scheduler Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface ISchedulerBase<out TSelf>
    {
        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>The target object.</returns>
        TSelf WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>The target object.</returns>
        TSelf WithScheduler(TaskScheduler taskScheduler);
    }
}