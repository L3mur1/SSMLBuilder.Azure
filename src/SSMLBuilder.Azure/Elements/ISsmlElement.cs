using SSMLBuilder.Azure.Models;
using System.Xml.Linq;

namespace SSMLBuilder.Azure.Elements
{
    /// <summary>
    /// Defines a contract for SSML elements that can be converted to SSML format.
    /// </summary>
    public interface ISsmlElement
    {
        /// <summary>
        /// Converts the implementing element to an SSML-formatted element.
        /// </summary>
        /// <param name="ns">The XML namespace to be used for the SSML element, if needed.</param>
        /// <returns>An <see cref="SsmlElement"/> that represents the current object in SSML format.</returns>
        SsmlElement ToSsml(XNamespace? ns = null);
    }
}