using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CGSpringChallenge2022.UnitTests
{
    public class PlayerHeroShould
    {
        [Fact]
        public void WriteMove()
        {
            // Arrange
            int x = 100;
            int y = 200;
            string expectation = @$"MOVE {x} {y} | WAIT;";
            Point destination = new Point(x, y);
            PlayerHero sut = new PlayerHero(new EntityBuilder().Build());
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            sut.Move(destination);

            // Assert
            writer.ToString().Should().Be(expectation);
        }
    }
}
