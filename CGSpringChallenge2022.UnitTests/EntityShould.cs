using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CGSpringChallenge2022.UnitTests
{
    public class EntityShould
    {
        [Fact]
        public void Parse()
        {
            // Arrange
            EntityBuilder entityBuilder = new EntityBuilder();

            // Act
            Entity entity = entityBuilder.Build();

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

    public class EntityBuilder
    {
        public const string TEST_ID = "1";
        public const string TEST_TYPE = "0";
        public const string TEST_X = "650";
        public const string TEST_Y = "330";
        public const string TEST_SHIELD = "0";
        public const string TEST_ISCONTROLLED = "0";
        public const string TEST_HEALTH = "50";
        public const string TEST_VX = "4";
        public const string TEST_VY = "5";
        public const string TEST_ISNEARBASE = "0";
        public const string TEST_THREAT = "1";

        private string _id, _type, _x, _y, _shield, _isControlled, _health, _vx, _vy, _isNearBase, _threat;

        public EntityBuilder()
        {
            _id = TEST_ID;
            _type = TEST_TYPE;
            _x = TEST_X;
            _y = TEST_Y;
            _shield = TEST_SHIELD;
            _isControlled = TEST_ISCONTROLLED;
            _health = TEST_HEALTH;
            _vx = TEST_VX;
            _vy = TEST_VY;
            _isNearBase = TEST_ISNEARBASE;
            _threat = TEST_THREAT;
        }

        public Entity Build() => new Entity(new string[] { _id, _type, _x, _y, _shield, _isControlled, _health, _vx, _vy, _isNearBase, _threat });

        public void WithId(int id) => _id = id.ToString();
        public void WithType(EntityType entityType) => _type = ((int)entityType).ToString();
        public void WithPosition(Point position)
        {
            _x = position.X.ToString();
            _y = position.Y.ToString();
        }
        public void WithShieldTimer(int timer) => _shield = timer.ToString();
        public void WithControlled(bool isControlled) => _isControlled = isControlled ? "1" : "0";
        public void WithHealth(int health) => _health = health.ToString();
        public void WithTrajectory(Point trajectory)
        {
            _vx = trajectory.X.ToString();
            _vy = trajectory.Y.ToString();
        }
        public void WithNearBase(bool isNearBase) => _isNearBase = isNearBase ? "1" : "0";
        public void WithThreat(ThreatType threat) => _threat = ((int)threat).ToString();
    }
}
