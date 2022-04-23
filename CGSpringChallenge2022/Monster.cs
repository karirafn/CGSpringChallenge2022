public class Monster : Entity
{
    public const int Speed = 400;
    public const int AggroRange = 5000;
    public const int AttackRange = 300;

    public Monster(Entity entity) : base(entity) { }
}
