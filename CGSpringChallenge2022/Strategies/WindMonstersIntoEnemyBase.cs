using System;
using System.Collections.Generic;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class WindMonstersIntoEnemyBase : StrategyBase, IStrategy
    {
        public WindMonstersIntoEnemyBase(Game game) : base(game)
        {
            HeroAction[0] = Defend;
            HeroAction[1] = Attack;
            HeroAction[2] = Attack;
        }

        private Func<bool>[] Defend(PlayerHero hero)
        {
            IEnumerable<Monster> threats = Game.Monsters
                .OrderBy(m => m.DistanceTo(Game.PlayerBase));

            IEnumerable<Monster> windTargets = threats
                .Where(m => m.ShieldTimer == 0)
                .Where(m => m.DistanceTo(Game.PlayerBase) <= Monster.AggroRange)
                .Where(m => m.DistanceTo(hero) < WindSpell.Range);

            IEnumerable<Hero> nearbyOpponents = Game.OpponentHeroes
                .Where(o => o.DistanceTo(Game.PlayerBase) <= Base.Visibility + Hero.Speed * 2);

            bool opponentNearby = nearbyOpponents
                .Any(o => o.DistanceTo(o) <= ControlSpell.Range + Hero.Speed);

            Hero opponent = nearbyOpponents
                .Where(o => threats.Any(t => t.DistanceTo(o) <= ShieldSpell.Range + Hero.Speed * 2))
                .FirstOrDefault();

            Monster imminentThreat = threats.FirstOrDefault(m => m.DistanceTo(Game.PlayerBase) < Monster.Speed * 10);

            return new Func<bool>[]
            {
                () => hero.TryCastShield(hero, ref Mana, opponentNearby && hero.ShieldTimer == 0),
                () => hero.TryCastWind(imminentThreat, Game.OpponentBase, ref Mana),
                () => hero.TryMove(imminentThreat),
                () => hero.TryCastControl(opponent, Game.OpponentBase, ref Mana),
                () => hero.TryMove(opponent),
                () => hero.TryCastWind(windTargets.FirstOrDefault(), Game.OpponentBase, ref Mana),
                () => hero.TryMove(threats.FirstOrDefault()),
                () => hero.TryMove(GetStartingPosition(hero)),
                () => hero.TryWait(),
            };
        }

        private Func<bool>[] DefendOpponent(PlayerHero hero)
        {
            IEnumerable<Monster> threats = Game.Monsters
                .OrderBy(m => m.DistanceTo(Game.PlayerBase));

            IEnumerable<Monster> windTargets = threats
                .Where(m => m.ShieldTimer == 0)
                .Where(m => m.DistanceTo(Game.PlayerBase) <= Monster.AggroRange)
                .Where(m => m.DistanceTo(hero) < WindSpell.Range);

            IEnumerable<Hero> nearbyOpponents = Game.OpponentHeroes
                .Where(o => o.DistanceTo(Game.PlayerBase) <= Base.Visibility + Hero.Speed * 2);

            bool opponentNearby = nearbyOpponents
                .Any(o => o.DistanceTo(o) <= ControlSpell.Range + Hero.Speed);

            Hero opponent = nearbyOpponents
                .Where(o => threats.Any(t => t.DistanceTo(o) <= ShieldSpell.Range + Hero.Speed * 2))
                .FirstOrDefault();

            Monster imminentThreat = threats.FirstOrDefault(m => m.DistanceTo(Game.PlayerBase) < Monster.Speed * 10);

            return new Func<bool>[]
            {
                () => hero.TryCastControl(opponent, Game.OpponentBase, ref Mana),
                () => hero.TryCastShield(hero, ref Mana, opponentNearby && hero.ShieldTimer == 0),
                () => hero.TryMove(opponent),
                () => hero.TryCastWind(windTargets.FirstOrDefault(), Game.OpponentBase, ref Mana),
                () => hero.TryMove(threats.FirstOrDefault()),
                () => hero.TryMove(GetStartingPosition(hero)),
                () => hero.TryWait(),
            };
        }

        private Func<bool>[] Attack(PlayerHero hero)
        {
            Monster controlTarget = Game.Monsters
                .Where(m => !m.IsControlled)
                .Where(m => m.Trajectory != Game.OpponentBase.Position)
                .Where(m => m.Position.DistanceTo(hero) > Hero.Visibility/2)
                .Where(m => m.Position.DistanceTo(Game.OpponentBase) < hero.Position.DistanceTo(Game.OpponentBase))
                .Where(m => m.DistanceTo(hero) <= ControlSpell.Range)
                .FirstOrDefault();

            Monster moveTarget = Game.Monsters
                .Where(m => m.Threat != ThreatType.OpponentBase)
                .Where(m => Game.IsOnOpponentSide(m))
                .OrderBy(m => m.DistanceTo(Game.OpponentBase))
                .FirstOrDefault();

            return new Func<bool>[]
            {
                () => hero.TryMove(new Point(Game.MapCenter.X + 10, Game.MapCenter.Y), !Game.IsOnOpponentSide(hero)),
                () => hero.TryCastControl(controlTarget, Game.OpponentBase, ref Mana),
                () => hero.TryMove(moveTarget),
                () => hero.TryMove(Game.MapCenter, hero.Position != Game.MapCenter),
                () => hero.TryMove(Game.Monsters.OrderBy(m => m.DistanceTo(hero)).FirstOrDefault()),
                () => hero.TryWait()
            };
        }
    }
}
