using System;
using System.Runtime.Serialization;

namespace Anori.ExpressionObservers.Exceptions
{
    [Serializable]
    public class ExpressionObserversException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionObserversException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExpressionObserversException(string message) : base(message)
        {
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionObserversException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        public ExpressionObserversException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}