using System;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public abstract class StrategyBase : IStrategy
    {
        private readonly PlayerHero[] _heroes;
        private readonly Point[] _startingPositions;

        protected int Mana;

        public StrategyBase(Game game)
        {
            Game = game;
            HeroAction = new Func<PlayerHero, Func<bool>[]>[Game.HeroCount];
            _heroes = Game.PlayerHeroes.ToArray();
            Mana = Game.PlayerBase.Mana;

            _startingPositions = new Point[Game.HeroCount];
            SetStartingPositions();
        }

        public Game Game { get; }
        public Func<PlayerHero, Func<bool>[]>[] HeroAction { get; }

        public Point GetStartingPosition(PlayerHero hero)
            => _startingPositions[Game.IsPlayerOne ? hero.Id : hero.Id - Game.HeroCount];

        public void PerformActions()
        {
            for (int i = 0; i < Game.HeroCount; i++)
            {
                Func<bool>[] heroActions = HeroAction[i].Invoke(_heroes[i]);
                foreach (Func<bool> action in heroActions) if (action.Invoke()) break;
            }
        }

        private void SetStartingPositions()
        {
            double angleDivision = Math.PI / (2 * (Game.HeroCount + 1));
            for (int i = 0; i < Game.HeroCount; i++)
            {
                double angle = (i + 1) * angleDivision;
                int dx = (int)(Base.Visibility * Math.Cos(angle));
                int dy = (int)(Base.Visibility * Math.Sin(angle));
                int x = Game.IsPlayerOne ? Game.PlayerBase.Position.X + dx : Game.PlayerBase.Position.X - dx;
                int y = Game.IsPlayerOne ? Game.PlayerBase.Position.Y + dy : Game.PlayerBase.Position.Y - dy;
                _startingPositions[i] = new Point(x, y);
            }
        }
    }
}
