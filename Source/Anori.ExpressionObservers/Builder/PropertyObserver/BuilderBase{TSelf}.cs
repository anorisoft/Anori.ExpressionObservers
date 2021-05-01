// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Exceptions;

    /// <summary>
    ///     The Property Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    internal abstract class BuilderBase<TSelf>
        where TSelf : BuilderBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderBase{TSelf}" /> class.
        /// </summary>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="isSilentActivate">if set to <c>true</c> [is silent activate].</param>
        protected BuilderBase(bool isAutoActivate, bool isSilentActivate)
        {
            this.IsAutoActivate = isAutoActivate;
            this.IsSilentActivate = isSilentActivate;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderBase{TSelf}" /> class.
        /// </summary>
        protected BuilderBase()
        {
        }

        /// <summary>
        ///     Gets or sets the observer mode.
        /// </summary>
        /// <value>
        ///     The observer mode.
        /// </value>
        private protected ObserverMode ObserverMode { get; set; } = ObserverMode.Default;

        /// <summary>
        ///     Gets or sets the observer flag.
        /// </summary>
        /// <value>
        ///     The observer flag.
        /// </value>
        public PropertyObserverFlag ObserverFlag { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is dispached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is dispached; otherwise, <c>false</c>.
        /// </value>
        private protected bool IsDispached { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is automatic activate.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is automatic activate; otherwise, <c>false</c>.
        /// </value>
        protected internal bool IsAutoActivate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is silent activate.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is silent activate; otherwise, <c>false</c>.
        /// </value>
        protected internal bool IsSilentActivate { get; set; }

        /// <summary>
        ///     Gets the task scheduler.
        /// </summary>
        /// <value>
        ///     The task scheduler.
        /// </value>
        private protected TaskScheduler? TaskScheduler { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is cached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is cached; otherwise, <c>false</c>.
        /// </value>
        private protected bool IsCached { get; private set; }

        /// <summary>
        ///     Gets the safety mode.
        /// </summary>
        /// <value>
        ///     The safety mode.
        /// </value>
        private protected LazyThreadSafetyMode SafetyMode { get; private set; }

        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        private protected Action? Action { get; private set; }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf AutoActivate()
        {
            if (this.IsAutoActivate)
            {
                throw new AutoActivateAlreadyActivatedException();
            }

            this.IsAutoActivate = true;
            return (TSelf)this;
        }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf Cached()
        {
            this.IsCached = true;
            this.SafetyMode = LazyThreadSafetyMode.None;
            return (TSelf)this;
        }

        /// <summary>
        ///     Cacheds the specified mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        protected TSelf Cached(LazyThreadSafetyMode mode)
        {
            this.IsCached = true;
            this.SafetyMode = mode;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf WithAction(Action action)
        {
            this.Action = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected TSelf WithGetterDispatcher()
        {
            this.IsDispached = true;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf WithScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return (TSelf)this;
        }
    }
}