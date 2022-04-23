using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class DefenseNoSpellsAttackSingle : IStrategy
    {
        private readonly Game _game;

        public DefenseNoSpellsAttackSingle(Game game)
        {
            _game = game;
        }

        public void PerformActions()
        {
            foreach (PlayerHero hero in _game.GetPlayerHeroes())
            {
                Enemy enemy = _game.GetEnemiesSortedByDistanceFromBase().FirstOrDefault();
                if (enemy is null)
                    hero.Wait();

                hero.Move(enemy);
            }
        }
    }
}
