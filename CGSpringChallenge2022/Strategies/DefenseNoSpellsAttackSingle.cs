using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class DefenseNoSpellsAttackSingle : StrategyBase, IStrategy
    {
        private readonly Game _game;

        public DefenseNoSpellsAttackSingle(Game game) : base(game)
        {
            _game = game;
        }

        public void PerformActions()
        {
            foreach (PlayerHero hero in _game.GetPlayerHeroes())
            {
                Monster enemy = GetMonstersSortedByDistanceFromBase().FirstOrDefault();
                if (enemy is null)
                    hero.Wait();

                hero.Move(enemy);
            }
        }
    }
}
