using static CGSpringChallenge2022.HeroAction;

namespace CGSpringChallenge2022.Models
{
    public class PlayerHero : Hero
    {
        public PlayerHero(int id, EntityType type, Point position, int shield, bool isControlled) : base(id, type, position, shield, isControlled)
        {
        }

        public void Wait() => new WaitAction(Id).Act();

        public void Move(Point point) => new MoveAction($"{point.X} {point.Y}", Id).Act();
        public void Move(ILocation destination) => Move(destination.Position);

        public void Wind(Point point) => new WindSpell($"{point.X} {point.Y}", Id).Act();
        public void Wind(ILocation direction) => Wind(direction.Position);

        public void Shield(int targetId) => new WindSpell($"{targetId}", Id).Act();

        public void Control(int targetId, Point point) => new ControlSpell($"{targetId} {point.X} {point.Y}", Id).Act();
        public void Control(int targetId, ILocation destination) => Control(targetId, destination.Position);

        public bool IsWithinRange(ILocation positionable, int range)
            => Position.DistanceTo(positionable) <= range;
    }
}
