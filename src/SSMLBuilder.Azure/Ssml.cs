namespace SSMLBuilder.Azure
{
    /// <summary>
    /// Contains constants for configuring Speech Synthesis Markup Language (SSML).
    /// </summary>
    public static class Ssml
    {
        /// <summary>
        /// The namespace URL for SSML as defined by the World Wide Web Consortium (W3C).
        /// </summary>
        public const string Namespace = "http://www.w3.org/2001/10/synthesis";

        /// <summary>
        /// The attribute name used to specify the version of SSML being used.
        /// </summary>
        public const string VersionAttribute = "version";

        /// <summary>
        /// The version number of SSML supported by this implementation.
        /// </summary>
        public const string VersionNumber = "1.0";
    }
}