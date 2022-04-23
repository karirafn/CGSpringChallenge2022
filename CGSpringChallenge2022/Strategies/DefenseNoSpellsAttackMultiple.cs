using System.Collections.Generic;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class DefenseNoSpellsAttackMultiple : StrategyBase, IStrategy
    {
        private readonly Game _game;

        public DefenseNoSpellsAttackMultiple(Game game) : base(game)
        {
            _game = game;
        }

        public void PerformActions()
        {
            List<PlayerHero> heroes = _game.GetPlayerHeroes().ToList();
            List<Monster> enemies = GetMonstersSortedByDistanceFromBase().ToList();

            if (!enemies.Any())
                heroes.ForEach(h => h.Move(_game.PlayerBase));

            if (enemies.Count == 1)
                heroes.ForEach(h => h.Move(enemies[0]));

            if (enemies.Count == 2)
            {
                heroes[0].Move(enemies.First());
                for (int i = 0; i < 2; i++)
                {
                    heroes[i].Move(enemies[i]);
                }
            }

            if (enemies.Count > 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    heroes[i].Move(enemies[i]);
                }
            }
        }
    }
}
