using FluentAssertions;
using Xunit;

namespace CGSpringChallenge2022.UnitTests
{
    public class BaseShould
    {
        [Fact]
        public void Initialize()
        {
            // Arrange
            int x = 5;
            int y = 10;

            // Act
            Base sut = new Base(x, y);

            // Assert
            sut.Position.X.Should().Be(x);
            sut.Position.Y.Should().Be(y);
        }
    }
}
