// -----------------------------------------------------------------------
// <copyright file="ObserverMode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver
{
    /// <summary>
    ///     Observer Mode.
    /// </summary>
    internal enum ObserverMode
    {
        /// <summary>
        ///     The default.
        /// </summary>
        Default,

        /// <summary>
        ///     The on notify property changed.
        /// </summary>
        OnNotifyPropertyChanged,

        /// <summary>
        ///     The on value cahnged.
        /// </summary>
        OnValueCahnged,
    }
}