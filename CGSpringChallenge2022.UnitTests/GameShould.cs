using FluentAssertions;
using Xunit;

namespace CGSpringChallenge2022.UnitTests
{
    public class GameShould
    {
        [Fact]
        public void Initialize()
        {
            // Arrange

            // Act
            Game game = new GameBuilder().Build();

            // Assert
            game.PlayerBase.Position.X.Should().Be(GameBuilder.TEST_BASE_X);
            game.PlayerBase.Position.Y.Should().Be(GameBuilder.TEST_BASE_Y);
            game.OpponentBase.Position.X.Should().Be(Game.MapSizeX - GameBuilder.TEST_BASE_X);
            game.OpponentBase.Position.Y.Should().Be(Game.MapSizeY - GameBuilder.TEST_BASE_Y);
            game.HeroCount.Should().Be(3);
        }
    }
}
