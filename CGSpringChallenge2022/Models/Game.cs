using CGSpringChallenge2022.Models;
using System.Collections.Generic;

public class Game
{
    public const int MapSizeX = 17630;
    public const int MapSizeY = 9000;

    private readonly Base[] _bases = new Base[2];
    private readonly List<PlayerHero> _playerHeroes = new List<PlayerHero>();
    private readonly List<Hero> _opponentHeroes = new List<Hero>();
    private readonly List<Monster> _monsters = new List<Monster>();
    
    public Game(string[] inputs, int heroCount)
    {
        int x = int.Parse(inputs[0]);
        int y = int.Parse(inputs[1]);

        _bases[0] = new Base(x, y);
        _bases[1] = new Base(MapSizeX - x, MapSizeY - y);
        HeroCount = heroCount;
        IsPlayerOne = x < MapCenter.X;
    }

    public static readonly Point MapCenter = new Point(MapSizeX / 2, MapSizeY / 2);

    public bool IsPlayerOne { get; }
    public int HeroCount { get; }
    public Base PlayerBase => _bases[0];
    public Base OpponentBase => _bases[1];
    public IEnumerable<PlayerHero> PlayerHeroes => _playerHeroes;
    public IEnumerable<Hero> OpponentHeroes => _opponentHeroes;
    public IEnumerable<Monster> Monsters => _monsters;

    public void UpdateBase(int index, string[] inputs)
    {
        _bases[index].Health = int.Parse(inputs[0]);
        _bases[index].Mana = int.Parse(inputs[1]);
    }

    public void ClearEntities()
    {
        _monsters.Clear();
        _playerHeroes.Clear();
        _opponentHeroes.Clear();
    }

    public void AddEntity(string[] inputs)
    {
        int id = int.Parse(inputs[0]);
        EntityType type = (EntityType)int.Parse(inputs[1]);
        Point position = new Point(int.Parse(inputs[2]), int.Parse(inputs[3]));
        int shield = int.Parse(inputs[4]);
        bool isControlled = int.Parse(inputs[5]) == 1;
        int Health = int.Parse(inputs[6]);
        bool isNearBase = int.Parse(inputs[9]) == 1;
        ThreatType threat = (ThreatType)int.Parse(inputs[10]);
        Point trajectory = new Point(int.Parse(inputs[7]), int.Parse(inputs[8]));

        switch (type)
        {
            case EntityType.PlayerHero:
                _playerHeroes.Add(new PlayerHero(id, type, position, shield, isControlled));
                break;
            case EntityType.OpponentHero:
                _opponentHeroes.Add(new Hero(id, type, position, shield, isControlled));
                break;
            case EntityType.Monster:
                _monsters.Add(new Monster(id, type, position, shield, isControlled, Health, trajectory, threat, isNearBase));
                break;
            default:
                break;
        }
    }
}
