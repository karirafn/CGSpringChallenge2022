using System;

public class PlayerHero : Entity
{
    private const string WAIT = nameof(WAIT);
    private const string MOVE = nameof(MOVE);
    private const string WIND = nameof(WIND);

    public PlayerHero(Entity entity) : base(entity) { }

    public void Wait() => Console.WriteLine(WAIT);

    public void Move(Point? destination)
    {
        if (destination is null)
            return;

        Console.WriteLine($"{MOVE} {destination?.X} {destination?.Y}");
    }

    public void Wind(Point? direction)
    {
        if (direction is null)
            return;

        Console.Write($"{WIND} {direction?.X} {direction?.Y}");
    }
}