using CGSpringChallenge2022.Models;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class DefenseWindSpellAttackSingle : StrategyBase, IStrategy
    {
        private readonly Game _game;

        public DefenseWindSpellAttackSingle(Game game) : base(game)
        {
            _game = game;
        }

        public void PerformActions()
        {
            PlayerHero[] heroes = _game.PlayerHeroes.ToArray();
            
            for (int i = 0; i < _game.HeroCount; i++)
            {
                Defend(heroes[i], i);
            }
        }
    }
}
