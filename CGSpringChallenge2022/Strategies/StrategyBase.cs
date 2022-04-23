using System.Collections.Generic;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public abstract class StrategyBase
    {
        private readonly Game _game;

        public StrategyBase(Game game)
        {
            _game = game;
        }

        public IEnumerable<Monster> GetMonstersSortedByDistanceFromBase()
            => _game.GetMonsters().OrderBy(e => e.Position.DistanceTo(_game.PlayerBase));
    }
}
