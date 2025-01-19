namespace SSMLBuilder.Azure
{
    /// <summary>
    /// Defines constant attribute names used in Speech Synthesis Markup Language (SSML).
    /// </summary>
    public static class SsmlAttributes
    {
        /// <summary>
        /// Represents the 'lang' attribute in SSML, specifying the language of the content.
        /// </summary>
        public const string Lang = "lang";

        /// <summary>
        /// Represents the 'name' attribute in SSML, specifying the name of the voice to use.
        /// </summary>
        public const string Name = "name";

        /// <summary>
        /// Represents the 'speak' attribute in SSML, used to mark the content that should be spoken.
        /// </summary>
        public const string Speak = "speak";

        /// <summary>
        /// Represents the 'text' attribute please mind this attribute is not supported by Azure Speech Service.
        /// </summary>
        public const string Text = "text";

        /// <summary>
        /// Represents the 'voice' attribute in SSML, used to specify the voice settings for speech synthesis.
        /// </summary>
        public const string Voice = "voice";
    }
}