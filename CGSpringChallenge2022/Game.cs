﻿using System;
using System.Linq;
using System.Collections.Generic;

public class Game
{
    public static (int X, int Y) MapSize { get; } = (17630, 9000);
    public Base PlayerBase { get; }
    public Base OpponentBase { get; }
    public IEnumerable<PlayerHero> Heroes { get; private set; }

    public Game()
    {
        string[] playerBasePosition = Console.ReadLine().Split(' ');
        _ = Console.ReadLine(); // Discard number of heroes
        int x = int.Parse(playerBasePosition[0]);
        int y = int.Parse(playerBasePosition[1]);

        PlayerBase = new Base(x, y);
        OpponentBase = new Base(MapSize.X - x, MapSize.Y - y);
    }

    public void UpdateBases()
    {
        UpdateBase(PlayerBase);
        UpdateBase(OpponentBase);
    }

    public void UpdateEntities()
    {
        IEnumerable<Entity> entities = Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(x => new Entity(Console.ReadLine().Split(' ')));

        Heroes = entities.Where(e => e.Type == EntityType.PlayerHero)
            .Select(e => new PlayerHero(e));
    }

    public void Act()
    {
        foreach (PlayerHero hero in Heroes)
            Console.WriteLine(hero.Action);
    }

    private void UpdateBase(Base @base)
    {
        string[] input = Console.ReadLine().Split(' ');
        @base.Health = int.Parse(input[0]);
        @base.Mana = int.Parse(input[1]);
    }
}
