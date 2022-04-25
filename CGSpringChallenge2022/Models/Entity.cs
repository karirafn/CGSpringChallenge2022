public abstract class Entity : IPositionable
{
    public Entity(int id, EntityType type, Point position, int shieldTimer, bool isControlled)
    {
        Id = id;
        Type = type;
        Position = position;
        ShieldTimer = shieldTimer;
        IsControlled = isControlled;
    }

    public int Id { get; }
    public EntityType Type { get; }
    public Point Position { get; }
    public int ShieldTimer { get; }
    public bool IsControlled { get; }
}
