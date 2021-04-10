// -----------------------------------------------------------------------
// <copyright file="NotActivatedException.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using JetBrains.Annotations;

    /// <summary>
    /// The Not Activated Exception class.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Exceptions.ExpressionObserversException" />
    [Serializable]
    public sealed class NotActivatedException : ExpressionObserversException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotActivatedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NotActivatedException()
            : base("Not activated.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotActivatedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        /// information about the source or destination.</param>
        public NotActivatedException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}