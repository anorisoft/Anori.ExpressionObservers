﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.Common;
    using Anori.ExpressionObservers.Exceptions;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The Property Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    internal abstract class PropertyObserverBuilderBase<TSelf>
        where TSelf : PropertyObserverBuilderBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyObserverBuilderBase{TSelf}"/> class.
        /// </summary>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="isSilentActivate">if set to <c>true</c> [is silent activate].</param>
        protected PropertyObserverBuilderBase(bool isAutoActivate, bool isSilentActivate)
        {
            this.IsAutoActivate = isAutoActivate;
            this.IsSilentActivate = isSilentActivate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyObserverBuilderBase{TSelf}"/> class.
        /// </summary>
        protected PropertyObserverBuilderBase()
        {
        }

        /// <summary>
        /// Gets or sets the observer flag.
        /// </summary>
        /// <value>
        /// The observer flag.
        /// </value>
        public PropertyObserverFlag ObserverFlag { get; set; }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf Cached();

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
        ///     Gets a value indicating whether this instance is dispached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is dispached; otherwise, <c>false</c>.
        /// </value>
        private protected bool IsDispached { get; set; }

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
        private protected TaskScheduler? TaskScheduler { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is cached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is cached; otherwise, <c>false</c>.
        /// </value>
        private protected bool IsCached { get; set; }

        /// <summary>
        ///     Gets the safety mode.
        /// </summary>
        /// <value>
        ///     The safety mode.
        /// </value>
        private protected LazyThreadSafetyMode SafetyMode { get; set; }

        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        private protected Action? Action { get; set; }
    }
}