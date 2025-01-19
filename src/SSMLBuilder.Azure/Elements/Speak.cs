using SSMLBuilder.Azure.Exceptions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SSMLBuilder.Azure.Elements
{
    /// <summary>
    /// Represents the root element for Speech Synthesis Markup Language (SSML) synthesis.
    /// </summary>
    public class Speak
    {
        private readonly string language;
        private readonly List<ISpeakSsmlElement> speakElements = new List<ISpeakSsmlElement>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Speak"/> class with the specified language.
        /// </summary>
        /// <param name="language">The language to be used for SSML synthesis.</param>
        protected Speak(string language) => this.language = language;

        /// <summary>
        /// Creates a <see cref="Speak"/> instance with the specified language.
        /// </summary>
        /// <param name="language">The language to be used. Defaults to English (US).</param>
        /// <returns>A new instance of the <see cref="Speak"/> class.</returns>
        public static Speak InLanguage(string language = AzureSsmlLanguages.English_US) => new Speak(language);

        /// <summary>
        /// Converts this instance to an SSML XElement.
        /// </summary>
        /// <returns>An <see cref="XElement"/> that represents this instance in SSML.</returns>
        /// <exception cref="SsmlBuilderException">Thrown if there are no speak elements.</exception>
        public XElement ToSsml()
        {
            if (speakElements.Count == 0)
            {
                throw SsmlBuilderException.NoSpeakElements;
            }

            XNamespace ns = Ssml.Namespace;
            var speakElement = new XElement(ns + SsmlAttributes.Speak,
                new XAttribute(Ssml.VersionAttribute, Ssml.VersionNumber),
                new XAttribute(XNamespace.Xml + SsmlAttributes.Lang, language));

            foreach (var element in speakElements)
            {
                speakElement.Add(element.ToSsml(ns));
            }

            return speakElement;
        }

        /// <summary>
        /// Returns a string that represents the current object in SSML format.
        /// </summary>
        /// <returns>A string that represents the current object in SSML.</returns>
        public override string ToString() => ToSsml().ToString();

        /// <summary>
        /// Adds an SSML element to the speak element.
        /// </summary>
        /// <param name="speakElement">The SSML element to add.</param>
        /// <returns>The <see cref="Speak"/> instance with the element added.</returns>
        public Speak WithElement(ISpeakSsmlElement speakElement)
        {
            speakElements.Add(speakElement);
            return this;
        }

        /// <summary>
        /// Adds a voice element to the speak element.
        /// </summary>
        /// <param name="voice">The voice element to add.</param>
        /// <returns>The <see cref="Speak"/> instance with the voice element added.</returns>
        public Speak WithVoice(Voice voice)
        {
            speakElements.Add(voice);
            return this;
        }
    }
}