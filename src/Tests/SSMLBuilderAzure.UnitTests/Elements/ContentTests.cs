using SSMLBuilder.Azure.Elements;

namespace SSMLBuilderAzure.UnitTests.Elements
{
    public class ContentTests
    {
        [Fact]
        public async Task WhenInLanguage()
        {
            // Arrange
            var sut = Content
                .Of("Why are snails slow?")
                .InLanguage("en-US");

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }

        [Fact]
        public async Task WhenPlainTextContent()
        {
            // Arrange
            var sut = Content.Of("Why are snails slow?");

            // Act
            var result = sut.ToString();

            // Assert
            await Verify(result);
        }
    }
}