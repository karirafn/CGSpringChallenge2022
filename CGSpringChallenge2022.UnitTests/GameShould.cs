using FluentAssertions;
using System;
using System.IO;
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
            game.OpponentBase.Position.X.Should().Be(Game.MapSize.X - GameBuilder.TEST_BASE_X);
            game.OpponentBase.Position.Y.Should().Be(Game.MapSize.Y - GameBuilder.TEST_BASE_Y);
            game.HeroCount.Should().Be(3);
        }

        [Fact]
        public void UpdateBases()
        {
            // Arrange
            Game game = new GameBuilder().Build();
            int playerHealth = 3;
            int playerMana = 5;
            int opponentHealth = 2;
            int opponentMana = 6;

            string data = string.Join(Environment.NewLine, new[]
            {
                $"{playerHealth} {playerMana}",
                $"{opponentHealth} {opponentMana}",
            });
            Console.SetIn(new StringReader(data));

            // Act
            game.UpdateBases();

            // Assert
            game.PlayerBase.Health.Should().Be(playerHealth);
            game.PlayerBase.Mana.Should().Be(playerMana);
            game.OpponentBase.Health.Should().Be(opponentHealth);
            game.OpponentBase.Mana.Should().Be(opponentMana);
        }
    }
}
