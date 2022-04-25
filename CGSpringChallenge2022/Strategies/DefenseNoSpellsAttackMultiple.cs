using CGSpringChallenge2022.Models;
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
            PlayerHero[] heroes = _game.PlayerHeroes.ToArray();
            Monster[] enemies = GetMonstersSortedByDistanceFromBase().ToArray();
            int enemyCount = enemies.Count();

            for (int i = 0; i < _game.HeroCount; i++)
            {
                PlayerHero hero = heroes[i];
                if (!enemies.Any())
                {
                    MoveToStartingPosition(hero, i);
                    continue;
                }

                if (enemyCount == 1)
                {
                    hero.Move(enemies[0]);
                    continue;
                }

                if (enemyCount == 2 && i == 3)
                {
                    hero.Move(enemies[1]);
                    continue;
                }

                hero.Move(enemies[i]);
            }
        }
    }
}
