using System;

public class PlayerHero : Entity
{
    private const string WAIT = nameof(WAIT);
    private const string MOVE = nameof(MOVE);
    private const string WIND = nameof(WIND);

    public PlayerHero(Entity entity) : base(entity) { }

    public void Wait() => Console.WriteLine(WAIT);

    public void Move(IPositionable? location)
    {
        if (location is null)
            return;

        Console.WriteLine($"{MOVE} {location?.Position.X} {location?.Position.Y}");
    }

    public void Wind(Point? direction)
    {
        if (direction is null)
            return;

        Console.Write($"{WIND} {direction?.X} {direction?.Y}");
    }
}