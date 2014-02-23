using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BCrypt.Net
{
    /// <summary>Exception for signalling parse errors. </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1058:TypesShouldNotExtendCertainBaseTypes")]
    public class SaltParseException : ApplicationException
    {
        /// <summary>Default constructor. </summary>
        public SaltParseException()
        {
        }

        /// <summary>Initializes a new instance of <see cref="SaltParseException"/>.</summary>
        /// <param name="message">The message.</param>
        public SaltParseException(string message)
            : base(message)
        {
        }

        /// <summary>Initializes a new instance of <see cref="SaltParseException"/>.</summary>
        /// <param name="message">       The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public SaltParseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>Initializes a new instance of <see cref="SaltParseException"/>.</summary>
        /// <param name="info">   The information.</param>
        /// <param name="context">The context.</param>
        protected SaltParseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
