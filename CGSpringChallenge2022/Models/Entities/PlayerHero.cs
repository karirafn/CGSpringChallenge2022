public class PlayerHero : Hero
{
    public PlayerHero(int id, EntityType type, Point position, int shield, bool isControlled) : base(id, type, position, shield, isControlled)
    {
    }

    public bool TryWait() => new WaitAction(Id).TryAct();

    public bool TryMove(Point point, bool condition = true)
        => new MoveAction($"{point.X} {point.Y}", Id).TryAct(Position != point && condition);

    public bool TryMove(ILocation destination, bool condition = true)
        => TryMove(destination.Position, condition);

    public bool TryMove(Entity target, bool condition = true)
        => target != null && TryMove(target.Position, condition);

    public bool TryCastWind(Point point, ref int mana, bool condition = true)
        => new WindSpell($"{point.X} {point.Y}", Id)
            .TryCast(ref mana, condition);

    public bool TryCastWind(ILocation direction, ref int mana, bool condition = true)
        => TryCastWind(direction.Position, ref mana, condition);

    public bool TryCastWind(Entity target, ILocation direction, ref int mana, bool condition = true)
        => target != null && TryCastWind(direction, ref mana, condition);

    public bool TryCastShield(Entity target, ref int mana, bool condition = true)
        => target != null && new ShieldSpell($"{target.Id}", Id)
            .TryCast(this, target, ref mana, condition);

    public bool TryCastControl(Entity target, Point destination, ref int mana, bool condition = true)
        => target != null && new ControlSpell($"{target.Id} {destination.X} {destination.Y}", Id)
            .TryCast(this, target, ref mana, condition);

    public bool TryCastControl(Entity target, ILocation destination, ref int mana, bool condition = true)
        => TryCastControl(target, destination.Position, ref mana, condition);
}
