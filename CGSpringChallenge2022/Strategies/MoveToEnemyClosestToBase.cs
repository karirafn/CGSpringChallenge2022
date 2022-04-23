using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class MoveToEnemyClosestToBase : IStrategy
    {
        private readonly Game _game;

        public MoveToEnemyClosestToBase(Game game)
        {
            _game = game;
        }

        public void PerformActions()
        {
            foreach (PlayerHero hero in _game.GetPlayerHeroes())
            {
                var destination = _game.GetEnemies().OrderBy(e => e.Position.DistanceTo(_game.PlayerBase)).First().Position;
                hero.Move(destination);
            }
        }
    }
}
