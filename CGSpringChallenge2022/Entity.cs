public class Entity
{
    public Entity(Entity entity)
    {
        Id = entity.Id;
        Type = entity.Type;
        Position = entity.Position;
        Trajectory = entity.Trajectory;
        Health = entity.Health;
        ShieldTimeLeft = entity.ShieldTimeLeft;
        IsControlled = entity.IsControlled;
        IsNearBase = entity.IsNearBase;
        Threat = entity.Threat;
    }

    public Entity(string[] inputs)
    {
        Id = int.Parse(inputs[0]);
        Type = (EntityType)int.Parse(inputs[1]);
        int x = int.Parse(inputs[2]);
        int y = int.Parse(inputs[3]);
        ShieldTimeLeft = int.Parse(inputs[4]);
        IsControlled = int.Parse(inputs[5]) == 1;
        Health = int.Parse(inputs[6]);
        int vx = int.Parse(inputs[7]);
        int vy = int.Parse(inputs[8]);
        IsNearBase = int.Parse(inputs[9]) == 1;
        Threat = (ThreatType)int.Parse(inputs[10]);
        Position = new Point(x, y);
        Trajectory = new Point(vx, vy);
    }

    public int Id { get; }
    public EntityType Type { get; }
    public Point Position { get; }
    public Point Trajectory { get; }
    public int Health { get; }
    public int ShieldTimeLeft { get; }
    public bool IsControlled { get; }
    public bool IsNearBase { get; }
    public ThreatType Threat { get; }
}
