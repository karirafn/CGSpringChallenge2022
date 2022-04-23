using System;
using System.IO;

namespace CGSpringChallenge2022.UnitTests
{
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

        public Entity Build()
        {
            string[] data = $"{_id} {_type} {_x} {_y} {_shield} {_isControlled} {_health} {_vx} {_vy} {_isNearBase} {_threat}".Split(' ');
            return new Entity(data);
        }

        public EntityBuilder WithId(int id) => WithOption(() => _id = id.ToString());
        public EntityBuilder WithType(EntityType entityType) => WithOption(() => _type = ((int)entityType).ToString());
        public EntityBuilder WithPosition(Point position)
        {
            _x = position.X.ToString();
            _y = position.Y.ToString();
            return this;
        }
        public EntityBuilder WithShieldTimer(int timer) => WithOption(() => _shield = timer.ToString());
        public EntityBuilder WithControlled(bool isControlled) => WithOption(() => _isControlled = isControlled ? "1" : "0");
        public EntityBuilder WithHealth(int health) => WithOption(() => _health = health.ToString());
        public EntityBuilder WithTrajectory(Point trajectory)
        {
            _vx = trajectory.X.ToString();
            _vy = trajectory.Y.ToString();
            return this;
        }
        public EntityBuilder WithNearBase(bool isNearBase) => WithOption(() => _isNearBase = isNearBase ? "1" : "0");
        public EntityBuilder WithThreat(ThreatType threat) => WithOption(() => _threat = ((int)threat).ToString());

        private EntityBuilder WithOption(Action action)
        {
            action.Invoke();
            return this;
        }
    }
}
