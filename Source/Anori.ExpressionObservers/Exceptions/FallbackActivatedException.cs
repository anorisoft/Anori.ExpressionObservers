// -----------------------------------------------------------------------
// <copyright file="FallbackActivatedException.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using JetBrains.Annotations;

    [Serializable]
    public class FallbackActivatedException : ExpressionObserversException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoActivateAlreadyActivatedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FallbackActivatedException()
            : base("Fallback is already activated.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoActivateAlreadyActivatedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        /// information about the source or destination.</param>
        public FallbackActivatedException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}