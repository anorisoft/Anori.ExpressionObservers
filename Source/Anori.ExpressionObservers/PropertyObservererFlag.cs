// -----------------------------------------------------------------------
// <copyright file="Class1.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;

    /// <summary>
    ///     Property Observerer Flag.
    /// </summary>
    [Flags]
    public enum PropertyObserverFlag
    {
        /// <summary>
        /// The none.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The throws exception if already activated.
        /// </summary>
        ThrowsExceptionIfAlreadyActivated = 1,

        /// <summary>
        ///     The throws exception if already deactivated.
        /// </summary>
        ThrowsExceptionIfAlreadyDeactivated = 2,

        /// <summary>
        ///     The throws exception on get if deactivated.
        /// </summary>
        ThrowsExceptionOnGetIfDeactivated = 4,

        /// <summary>
        /// The throws all.
        /// </summary>
        ThrowsAllExceptions = ThrowsExceptionIfAlreadyActivated | ThrowsExceptionIfAlreadyDeactivated | ThrowsExceptionOnGetIfDeactivated,

    }
}