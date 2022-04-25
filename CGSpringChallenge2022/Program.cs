using CGSpringChallenge2022.Strategies;
using System;

class Player
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int heroesPerPlayer = int.Parse(Console.ReadLine()); // Always 3
        Game game = new Game(inputs, heroesPerPlayer);
        IStrategy strategy = new DefenseWindSpellAttackSingle(game);

        
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                game.UpdateBase(i, inputs);
            }

            int entityCount = int.Parse(Console.ReadLine());
            game.ClearEntities();
            for (int i = 0; i < entityCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                game.AddEntity(inputs);
            }

            strategy.PerformActions();
        }
    }
}
