using FluentAssertions;
using Xunit;

namespace CGSpringChallenge2022.UnitTests
{
    public class EntityShould
    {
        [Fact]
        public void Parse()
        {
            // Arrange

            // Act
            Entity entity = new EntityBuilder().Build();

            // Assert
            entity.Id.ToString().Should().Be(EntityBuilder.TEST_ID);
            ((int)entity.Type).ToString().Should().Be(EntityBuilder.TEST_TYPE);
            entity.Position.X.ToString().Should().Be(EntityBuilder.TEST_X);
            entity.Position.Y.ToString().Should().Be(EntityBuilder.TEST_Y);
            entity.ShieldTimeLeft.ToString().Should().Be(EntityBuilder.TEST_SHIELD);
            (entity.IsControlled ? "1" : "0").Should().Be(EntityBuilder.TEST_ISCONTROLLED);
            entity.Health.ToString().Should().Be(EntityBuilder.TEST_HEALTH);
            entity.Trajectory.X.ToString().Should().Be(EntityBuilder.TEST_VX);
            entity.Trajectory.Y.ToString().Should().Be(EntityBuilder.TEST_VY);
            (entity.IsNearBase ? "1" : "0").Should().Be(EntityBuilder.TEST_ISNEARBASE);
            ((int)entity.Threat).ToString().Should().Be(EntityBuilder.TEST_THREAT);
        }
    }
}
