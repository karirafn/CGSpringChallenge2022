using System;

public class PlayerHero : Entity
{
    public const int Visibility = 2200;
    public const int WindRange = 1280;

    private const string WAIT = nameof(WAIT);
    private const string MOVE = nameof(MOVE);
    private const string WIND = nameof(WIND);
    private const string SHIELD = nameof(SHIELD);
    private const string CONTROL = nameof(CONTROL);

    public PlayerHero(Entity entity) : base(entity) { }

    public void Wait() => Console.WriteLine(WAIT);

    public void Move(IPositionable destination) => Move(destination?.Position);
    public void Move(Point? destination)
    {
        if (destination is null)
            return;

        Console.WriteLine($"{MOVE} {destination?.X} {destination?.Y}");
    }

    public void Wind(IPositionable direction) => Move(direction?.Position);
    public void Wind(Point? direction)
    {
        if (direction is null)
            return;

        Console.Write($"{WIND} {direction?.X} {direction?.Y}");
    }

    public void Shield(int id)
        => Console.WriteLine($"{SHIELD} {id}");

    public void Control(int id, IPositionable destination) => Control(id, destination?.Position);
    public void Control(int id, Point? destination)
    {
        if (destination is null)
            return;

        Console.WriteLine($"{CONTROL} {id} {destination?.X} {destination?.Y}");
    }
}