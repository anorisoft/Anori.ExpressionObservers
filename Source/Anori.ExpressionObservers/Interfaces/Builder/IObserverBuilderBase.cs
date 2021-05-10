// -----------------------------------------------------------------------
// <copyright file="IObserverBuilderBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System.Threading.Tasks;

    /// <summary>
    ///     The I Property Value Observer Builder Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface IObserverBuilderBase<out TSelf>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        TSelf AutoActivate();
    }

    public interface IObserverBuilderSchedulerBase<out TSelf>
    {

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>The target object.</returns>
        TSelf WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>The target object.</returns>
        TSelf WithScheduler(TaskScheduler taskScheduler);
    }
}