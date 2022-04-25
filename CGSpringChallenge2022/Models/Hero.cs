public class Hero : Entity
{
    public const int Visibility = 2200;

    public Hero(int id, EntityType type, Point position, int shield, bool isControlled)
        : base(id, type ,position, shield, isControlled)
    {

    }
}