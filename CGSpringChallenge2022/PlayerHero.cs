using System;

public class PlayerHero : Entity
{
    private const string MOVE = nameof(MOVE);
    private const string WAIT = nameof(WAIT);

    public PlayerHero(Entity entity) : base(entity) { }

    public void Move(Point destination) => Console.WriteLine(@$"{MOVE} {destination.X} {destination.Y} | {WAIT};");
}