// -----------------------------------------------------------------------
// <copyright file="IGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// The I Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface IGetterTaskScheduler<out TSelf>
        where TSelf : IGetterTaskScheduler<TSelf>
    {
        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns></returns>
        TSelf WithGetterTaskScheduler(TaskScheduler taskScheduler);
    }
}