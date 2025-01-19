using System.Xml.Linq;

namespace SSMLBuilder.Azure.Elements
{
    /// <summary>
    /// Defines a contract for elements that can be converted to an SSML (Speech Synthesis Markup Language) format and placed in root Speak element.
    /// </summary>
    public interface ISpeakSsmlElement
    {
        /// <summary>
        /// Converts the implementing element to an SSML XML element, member of root Speak element.
        /// </summary>
        /// <param name="ns">The XML namespace to be used for the SSML element, if necessary.</param>
        /// <returns>An <see cref="XElement"/> that represents the current object in SSML format.</returns>
        XElement ToSsml(XNamespace? ns = null);
    }
}