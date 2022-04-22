using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int baseX = int.Parse(inputs[0]); // The corner of the map representing your base
        int baseY = int.Parse(inputs[1]);
        int heroesPerPlayer = int.Parse(Console.ReadLine()); // Always 3

        // game loop
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int health = int.Parse(inputs[0]); // Each player's base health
                int mana = int.Parse(inputs[1]); // Ignore in the first league; Spend ten mana to cast a spell
            }

            IEnumerable<Entity> entities = Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(x => new Entity(Console.ReadLine().Split(' ')));

            IEnumerable<PlayerHero> heroes = entities.Where(e => e.Type == EntityType.PlayerHero)
                .Select(e => new PlayerHero(e));

            foreach (PlayerHero hero in heroes)
                Console.WriteLine(hero.Action);
        }
    }
}
