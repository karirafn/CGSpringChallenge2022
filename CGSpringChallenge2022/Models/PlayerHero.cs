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
        public void Move(IPositionable destination) => Move(destination.Position);

        public void Wind(Point point) => new WindSpell($"{point.X} {point.Y}", Id).Act();
        public void Wind(IPositionable direction) => Wind(direction.Position);

        public void Shield(int targetId) => new WindSpell($"{targetId}", Id).Act();

        public void Control(int targetId, Point point) => new WindSpell($"{targetId} {point.X} {point.Y}", Id).Act();
        public void Control(int targetId, IPositionable destination) => Control(targetId, destination.Position);
    }
}
