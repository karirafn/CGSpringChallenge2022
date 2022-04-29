using CGSpringChallenge2022.Strategies;
using System;

class Player
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int heroCount = int.Parse(Console.ReadLine());
        Game game = new Game(inputs, heroCount);

        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                game.UpdateBase(i, inputs);
            }

            game.ClearEntities();
            int entityCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < entityCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                game.AddEntity(inputs);
            }

            new WindMonstersIntoEnemyBase(game).PerformActions();
        }
    }
}
