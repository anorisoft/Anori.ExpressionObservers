// -----------------------------------------------------------------------
// <copyright file="Deferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;

    public readonly struct Deferrer : IDisposable
    {
        private readonly Action release;

        public Deferrer(Action @catch, Action release)
        {
            @catch();
            this.release = release;
        }

        public void Dispose() => this.release();
    }
}