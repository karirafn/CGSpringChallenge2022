using System.Collections.Generic;
using System.Linq;

public class Game
{
    private Base[] _bases = new Base[2];
    
    public Game(string[] inputs, int heroCount)
    {
        int x = int.Parse(inputs[0]);
        int y = int.Parse(inputs[1]);

        _bases[0] = new Base(x, y);
        _bases[1] = new Base(MapSize.X - x, MapSize.Y - y);
        HeroCount = heroCount;
    }

    public static (int X, int Y) MapSize { get; } = (17630, 9000);
    public int HeroCount { get; }
    public List<Entity> Entities { get; private set; } = new List<Entity>();
    public Base PlayerBase => _bases[0];
    public Base OpponentBase => _bases[1];

    public void UpdateBase(int index, string[] inputs)
    {
        _bases[index].Health = int.Parse(inputs[0]);
        _bases[index].Mana = int.Parse(inputs[1]);
    }

    public void AddEntity(string[] inputs) => Entities.Add(new Entity(inputs));
    public IEnumerable<PlayerHero> GetPlayerHeroes() => Entities.Where(e => e.Type == EntityType.PlayerHero).Select(e => new PlayerHero(e));
    public IEnumerable<Enemy> GetEnemies() => Entities.Where(e => e.Type != EntityType.PlayerHero).Select(e => new Enemy(e));

    public void Act(IStrategy strategy) => strategy.PerformActions();

    public IEnumerable<Enemy> GetEnemiesSortedByDistanceFromBase()
        => GetEnemies().OrderBy(e => e.Position.DistanceTo(PlayerBase));
}
