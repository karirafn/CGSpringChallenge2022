public class Monster : Entity
{
    public const int Speed = 400;
    public const int AggroRange = 5000;
    public const int AttackRange = 300;

    public Monster(int id, EntityType type, Point position, int shield, bool isControlled, int health, Point trajetctory, ThreatType threat, bool isNearBase)
        : base(id, type, position, shield, isControlled)
    {
        Health = health;
        Trajectory = trajetctory;
        Threat = threat;
        IsNearBase = isNearBase;
    }

    public int Health { get; }
    public Point Trajectory { get; }
    public ThreatType Threat { get; }
    public bool IsNearBase { get; }
}
