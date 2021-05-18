// -----------------------------------------------------------------------
// <copyright file="FallbackAlreadyDefineException.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Fallback Already Define Exception class.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Exceptions.ExpressionObserversException" />
    [Serializable]
    public class FallbackAlreadyDefineException : ExpressionObserversException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FallbackAlreadyDefineException" /> class.
        /// </summary>
        public FallbackAlreadyDefineException()
            : base("Fallback is already activated.")
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FallbackAlreadyDefineException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        public FallbackAlreadyDefineException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}