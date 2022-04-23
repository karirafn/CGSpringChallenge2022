using CGSpringChallenge2022.Strategies;
using System;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int heroesPerPlayer = int.Parse(Console.ReadLine()); // Always 3
        Game game = new Game(inputs, heroesPerPlayer);
        IStrategy strategy = new MoveToEnemyClosestToBase(game);

        
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                game.UpdateBase(i, inputs);
            }

            int entityCount = int.Parse(Console.ReadLine());
            game.Entities.Clear();
            for (int i = 0; i < entityCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                game.AddEntity(inputs);
            }

            game.Act(strategy);
        }
    }
}
