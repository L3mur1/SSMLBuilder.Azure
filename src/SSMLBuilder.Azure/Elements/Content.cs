using SSMLBuilder.Azure.Models;
using System.Xml.Linq;

namespace SSMLBuilder.Azure.Elements
{
    /// <summary>
    /// Represents the text content for an element in Speech Synthesis Markup Language (SSML).
    /// </summary>
    public class Content : ISsmlElement
    {
        private readonly string text;
        private string? language = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text content to be synthesized within a element.</param>
        protected Content(string text) => this.text = text;

        /// <summary>
        /// Creates a new instance of the <see cref="Content"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text content to be synthesized.</param>
        /// <returns>A new instance of the <see cref="Content"/> class.</returns>
        public static Content Of(string text) => new Content(text);

        /// <summary>
        /// Sets the language for the content.
        /// </summary>
        /// <param name="language">The language code. Defaults to English (US).</param>
        /// <returns>The current instance of the <see cref="Content"/> class with the specified language setting.</returns>
        public Content InLanguage(string language = AzureSsmlLanguages.English_US)
        {
            this.language = language;
            return this;
        }

        /// <summary>
        /// Converts the content to an SSML element suitable for insertion within tags.
        /// </summary>
        /// <param name="ns">The XML namespace to use, if any.</param>
        /// <returns>An instance of the <see cref="SsmlElement"/> class representing the SSML element containing the text.</returns>
        public SsmlElement ToSsml(XNamespace? ns = null)
        {
            ns ??= XNamespace.None;

            if (language != null)
            {
                var xElement = new XElement(ns + SsmlAttributes.Lang,
                    new XAttribute(XNamespace.Xml + SsmlAttributes.Lang, language),
                    text);

                return SsmlElement.Of(xElement);
            }

            return SsmlElement.OfPlainText(text, ns);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => ToSsml().ToString();
    }
}