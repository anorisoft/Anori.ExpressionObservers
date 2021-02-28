// -----------------------------------------------------------------------
// <copyright file="ExpressionObserversException.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     ExpressionObservers Exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ExpressionObserversException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionObserversException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExpressionObserversException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionObserversException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ExpressionObserversException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///     When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see>
        ///     with information about the exception.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}