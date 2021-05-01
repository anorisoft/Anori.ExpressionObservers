// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System.Threading.Tasks;

    /// <summary>
    ///     The I Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TTarget">The type of the self.</typeparam>
    public interface IPropertyObserverScheduler<out TTarget>
    {
        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>The target object.</returns>
        TTarget WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>The target object.</returns>
        TTarget WithScheduler(TaskScheduler taskScheduler);
    }
}