// -----------------------------------------------------------------------
// <copyright file="IGetterValuePropertyObserverAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    public interface IGetterValuePropertyObserverAndDeferrer<TResult> : IPropertyObserverBase<IGetterValuePropertyObserverAndDeferrer<TResult>>
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is deferred.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </value>
        bool IsDeferred { get; }
    }
}