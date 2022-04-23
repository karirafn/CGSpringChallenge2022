using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class DefenseNoSpells : IStrategy
    {
        private readonly Game _game;

        public DefenseNoSpells(Game game)
        {
            _game = game;
        }

        public void PerformActions()
        {
            foreach (PlayerHero hero in _game.GetPlayerHeroes())
            {
                Point? destination = _game.GetEnemies().OrderBy(e => e.Position.DistanceTo(_game.PlayerBase)).FirstOrDefault()?.Position;
                if (destination is null)
                    hero.Wait();

                hero.Move(destination);
            }
        }
    }
}
