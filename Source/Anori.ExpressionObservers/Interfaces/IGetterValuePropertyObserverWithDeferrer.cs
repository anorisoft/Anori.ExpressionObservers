// -----------------------------------------------------------------------
// <copyright file="IGetterValuePropertyObserverWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    /// <summary>
    ///     The Getter Value Property Observer With Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface
        IGetterValuePropertyObserverWithDeferrer<TResult> : IPropertyObserverBase<
            IGetterValuePropertyObserverWithDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is deferred.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </value>
        bool IsDeferred { get; }

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>Disposable deferrer.</returns>
        IDisposable Defer();

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The GetValue().</returns>
        TResult? GetValue();
    }
}