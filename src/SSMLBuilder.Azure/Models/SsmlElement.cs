using System.Xml.Linq;

namespace SSMLBuilder.Azure.Models
{
    /// <summary>
    /// Represents an element in Speech Synthesis Markup Language (SSML).
    /// </summary>
    public class SsmlElement
    {
        /// <summary>
        /// Gets a value indicating whether this instance represents plain text.
        /// </summary>
        public bool IsPlainText { get; }

        /// <summary>
        /// Gets the underlying XElement representation of this SSML element.
        /// </summary>
        public XElement XElement { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsmlElement"/> class.
        /// </summary>
        /// <param name="xElement">The XML element representing this SSML element.</param>
        /// <param name="isPlainText">Indicates whether the element is plain text.</param>
        protected SsmlElement(XElement xElement, bool isPlainText)
        {
            XElement = xElement;
            IsPlainText = isPlainText;
        }

        /// <summary>
        /// Creates an SSML element from an XElement.
        /// </summary>
        /// <param name="xElement">The XML element to wrap as an SSML element.</param>
        /// <returns>An instance of <see cref="SsmlElement"/>.</returns>
        public static SsmlElement Of(XElement xElement) => new SsmlElement(xElement, false);

        /// <summary>
        /// Creates an SSML element that represents plain text, which is not natively accepted by some speech synthesis services.
        /// </summary>
        /// <param name="text">The text to wrap in an XML element.</param>
        /// <param name="ns">The namespace to use for the XML element, if any.</param>
        /// <returns>An SSML element that wraps the plain text.</returns>
        public static SsmlElement OfPlainText(string text, XNamespace? ns = null)
        {
            ns ??= XNamespace.None;
            var textElement = new XElement(ns + SsmlAttributes.Text, text);
            return new SsmlElement(textElement, true);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => XElement.ToString();
    }
}