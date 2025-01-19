using SSMLBuilder.Azure.Elements;

namespace SSMLBuilderAzure.UnitTests.Elements
{
    public class VoiceTests
    {
        [Fact()]
        public async Task WhenMultipleContents()
        {
            // Arrange
            var sut = Speak.InLanguage()
                .WithVoice(Voice.Named("en-US-AvaMultilingualNeural")

                .WithContent(Content.Of("Why are snails slow?"))

                .WithContent(Content.Of("- Because they carry their houses on their backs!")));

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }

        [Fact()]
        public async Task WhenNoContents_Throw()
        {
            // Arrange
            var sut = Speak.InLanguage()
                .WithVoice(Voice.Named("en-US-AvaMultilingualNeural"));

            // Act && Assert
            await Throws(sut.ToSsml);
        }

        [Fact()]
        public async Task WhenPlainTextContent()
        {
            // Arrange
            var sut = Speak.InLanguage()
                .WithVoice(Voice.Named("en-US-AvaMultilingualNeural")
                .WithContent(Content.Of("Why are snails slow?")));

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }

        [Fact()]
        public async Task WhenSsmlContent()
        {
            // Arrange
            var sut = Speak.InLanguage()
                .WithVoice(Voice.Named("en-US-AvaMultilingualNeural")
                .WithContent(Content
                .Of("Why are snails slow?")
                .InLanguage("en-US")));

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }
    }
}