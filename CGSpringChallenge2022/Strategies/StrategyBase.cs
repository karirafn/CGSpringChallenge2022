using CGSpringChallenge2022.Models;
using System;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public abstract class StrategyBase
    {
        private readonly double _angleDivision;

        public StrategyBase(Game game)
        {
            Game = game;
            Heroes = Game.PlayerHeroes.ToArray();
            Mana = Game.PlayerBase.Mana;
            _angleDivision = Math.PI / (2 * (Game.HeroCount + 1));
        }

        public Game Game { get; }
        public PlayerHero[] Heroes { get; }
        public int Mana { get; set; }
        public int ActionsPerformed { get; set; } = 0;

        public bool HasAvailableActions => ActionsPerformed < Game.HeroCount;

        public void PerformAction(Action action)
        {
            if (HasAvailableActions)
                action.Invoke();
        }

        public void MoveToStartingPosition(PlayerHero hero)
        {
            int multiplier = Game.IsPlayerOne ? hero.Id + 1 : hero.Id - Game.HeroCount + 1;
            double angle = multiplier * _angleDivision;
            int xOffset = (int)(Base.Visibility * Math.Cos(angle));
            int yOffset = (int)(Base.Visibility * Math.Sin(angle));
            int x = Game.IsPlayerOne ? Game.PlayerBase.Position.X + xOffset : Game.PlayerBase.Position.X - xOffset;
            int y = Game.IsPlayerOne ? Game.PlayerBase.Position.Y + yOffset : Game.PlayerBase.Position.Y - yOffset;
            Point destination = new Point(x, y);
            hero.Move(destination);
        }

        public bool IsOnOpponentSide(ILocation location)
            => (Game.IsPlayerOne && Game.MapCenter.X < location.Position.X) || (!Game.IsPlayerOne && Game.MapCenter.X > location.Position.X);
    }
}
