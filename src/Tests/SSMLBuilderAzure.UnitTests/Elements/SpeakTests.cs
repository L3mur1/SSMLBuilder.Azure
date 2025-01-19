using SSMLBuilder.Azure.Elements;

namespace SSMLBuilderAzure.UnitTests.Elements
{
    public class SpeakTests
    {
        [Fact()]
        public async Task WhenElement()
        {
            // Arrange
            var sut = Speak.InLanguage("en-US")
                .WithElement(Voice
                .Named("en-US-AvaMultilingualNeural")
                .WithContent(Content.Of("Why are snails slow?")));

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }

        [Fact()]
        public async Task WhenMultipleElements()
        {
            // Arrange
            var sut = Speak.InLanguage("en-US")

                .WithElement(Voice
                .Named("en-US-AvaMultilingualNeural")
                .WithContent(Content.Of("Why are snails slow?")))

                .WithVoice(Voice
                .Named("en-US-AndrewMultilingualNeural")
                .WithContent(Content.Of("- Because they carry their houses on their backs!")));

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }

        [Fact()]
        public async Task WhenNoSpeakElements_Throw()
        {
            // Arrange
            var sut = Speak.InLanguage();

            // Act && Assert
            await Throws(sut.ToSsml);
        }

        [Fact]
        public async Task WhenVoice()
        {
            // Arrange
            var sut = Speak
                .InLanguage("en-US")

                .WithVoice(Voice
                .Named("en-US-AvaMultilingualNeural")
                .WithContent(Content.Of("Why are snails slow?")));

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }
    }
}