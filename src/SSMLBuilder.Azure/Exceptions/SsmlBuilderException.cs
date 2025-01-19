using System;

namespace SSMLBuilder.Azure.Exceptions
{
    /// <summary>
    /// Represents errors that occur during SSML generation.
    /// </summary>
    public class SsmlBuilderException : Exception
    {
        /// <summary>
        /// Gets a pre-defined exception indicating that no content exists for SSML synthesis.
        /// </summary>
        public static SsmlBuilderException NoContents => new SsmlBuilderException("No contents.");

        /// <summary>
        /// Gets a pre-defined exception indicating that no speak elements are present in the SSML document.
        /// </summary>
        public static SsmlBuilderException NoSpeakElements => new SsmlBuilderException("No speak elements.");

        /// <summary>
        /// Initializes a new instance of the <see cref="SsmlBuilderException"/> class.
        /// </summary>
        public SsmlBuilderException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsmlBuilderException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SsmlBuilderException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsmlBuilderException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public SsmlBuilderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}