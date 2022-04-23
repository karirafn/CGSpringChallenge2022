public class PlayerHero : Entity
{
    private const string MOVE = nameof(MOVE);
    private const string WAIT = nameof(WAIT);

    public PlayerHero(Entity entity) : base(entity) { }

    // In the first league: MOVE <x> <y> | WAIT; In later leagues: | SPELL <spellParams>;
    public string Action { get; private set; } = WAIT;
    public Entity Entity { get; }

    public void Move(IPositionable positionable)
    {
        if (!Action.Contains(MOVE))
            Action = $"{MOVE} {positionable.Position.X} {positionable.Position.Y} | {WAIT}";
    }
}