using CGSpringChallenge2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public abstract class StrategyBase
    {
        private readonly Game _game;
        private readonly double _angleDivision;

        public StrategyBase(Game game)
        {
            _game = game;
            _angleDivision = Math.PI / (2 * (_game.HeroCount + 1));
        }

        public IEnumerable<Monster> GetMonstersSortedByDistanceFromBase()
            => _game.Monsters.OrderBy(e => e.Position.DistanceTo(_game.PlayerBase));

        public IEnumerable<Monster> GetMonstersTargettingBase()
            => _game.Monsters.Where(m => m.Threat == ThreatType.PlayerBase)
                .OrderBy(e => e.Position.DistanceTo(_game.PlayerBase));

        public void MoveToStartingPosition(PlayerHero hero, int index)
        {
            double angle = (index + 1) * _angleDivision;
            int x = (int)(Base.Visibility * Math.Cos(angle));
            int y = (int)(Base.Visibility * Math.Sin(angle));
            Point destination = new Point(x, y);
            hero.Move(destination);
        }

        public bool IsWithinRange(Hero hero, IPositionable place, int range)
            => place.Position.DistanceTo(hero) <= range;

        public void Defend(PlayerHero hero, int heroIndex)
        {
            IEnumerable<Monster> threat = GetMonstersTargettingBase();
            if (threat.Any())
                hero.Move(threat.First());
            else
                MoveToStartingPosition(hero, heroIndex);
        }
    }
}
