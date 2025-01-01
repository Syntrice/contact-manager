using ContactManager.Options;
using FluentAssertions;

namespace ContactManager.Tests.Options
{
    [TestFixture]
    public class ConsoleUIOptionsTests
    {
        [Test]
        public void SetStartingState_WithInvalidType_ThrowsArgumentException()
        {
            // Arrange
            ConsoleUIOptions options = new ConsoleUIOptions();

            // Act
            Action act = () =>
            {
                options.StartingState = typeof(object);
            };

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
