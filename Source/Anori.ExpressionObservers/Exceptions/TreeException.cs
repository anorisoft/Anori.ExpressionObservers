﻿// -----------------------------------------------------------------------
// <copyright file="TreeException.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using JetBrains.Annotations;

    [Serializable]
    public class TreeException : ExpressionObserversException
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TreeException(string message)
            : base(message)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TreeException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        /// information about the source or destination.</param>
        public TreeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}