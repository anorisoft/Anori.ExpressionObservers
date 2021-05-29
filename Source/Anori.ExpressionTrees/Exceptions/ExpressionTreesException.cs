﻿// -----------------------------------------------------------------------
// <copyright file="ExpressionTreesException.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     ExpressionObservers Exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public abstract class ExpressionTreesException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTreesException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected ExpressionTreesException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTreesException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ExpressionTreesException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}