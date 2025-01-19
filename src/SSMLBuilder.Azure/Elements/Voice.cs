using SSMLBuilder.Azure.Exceptions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SSMLBuilder.Azure.Elements
{
    /// <summary>
    /// Represents a voice element in Speech Synthesis Markup Language (SSML) synthesis.
    /// </summary>
    public class Voice : ISpeakSsmlElement
    {
        private readonly List<Content> contents = new List<Content>();
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Voice"/> class with the specified voice name.
        /// </summary>
        /// <param name="name">The name of the voice to be used for SSML synthesis.</param>
        protected Voice(string name) => this.name = name;

        /// <summary>
        /// Creates a <see cref="Voice"/> instance with the specified voice name.
        /// </summary>
        /// <param name="name">The name of the voice to be used.</param>
        /// <returns>A new instance of the <see cref="Voice"/> class.</returns>
        public static Voice Named(string name) => new Voice(name);

        /// <summary>
        /// Converts this instance to an SSML XElement.
        /// </summary>
        /// <param name="ns">The XML namespace to use for the SSML elements.</param>
        /// <returns>An <see cref="XElement"/> that represents this voice in SSML.</returns>
        /// <exception cref="SsmlBuilderException">Thrown if there are no contents to synthesize.</exception>
        public XElement ToSsml(XNamespace? ns = null)
        {
            if (contents.Count == 0)
            {
                throw SsmlBuilderException.NoContents;
            }

            ns ??= XNamespace.None;
            var voiceElement = new XElement(ns + SsmlAttributes.Voice, new XAttribute(SsmlAttributes.Name, name));

            foreach (var content in contents)
            {
                var ssmlContent = content.ToSsml(ns);
                if (ssmlContent.IsPlainText)
                {
                    voiceElement.Add(new XText(ssmlContent.XElement.Value));
                }
                else
                {
                    voiceElement.Add(ssmlContent.XElement);
                }
            }

            return voiceElement;
        }

        /// <summary>
        /// Returns a string that represents the current object in SSML format.
        /// </summary>
        /// <returns>A string that represents the current object in SSML.</returns>
        public override string ToString() => ToSsml().ToString();

        /// <summary>
        /// Adds content to the voice element.
        /// </summary>
        /// <param name="content">The content to add to this voice element.</param>
        /// <returns>The <see cref="Voice"/> instance with the content added.</returns>
        public Voice WithContent(Content content)
        {
            contents.Add(content);
            return this;
        }
    }
}