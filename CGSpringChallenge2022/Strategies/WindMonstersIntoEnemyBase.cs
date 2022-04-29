using System;
using System.Linq;

namespace CGSpringChallenge2022.Strategies
{
    public class WindMonstersIntoEnemyBase : StrategyBase, IStrategy
    {
        public WindMonstersIntoEnemyBase(Game game) : base(game)
        {
            HeroAction[0] = DefendAgainstMonsters;
            HeroAction[1] = Attack;
            HeroAction[2] = DefendAgainstMonsters;
        }

        private Func<bool>[] DefendAgainstMonsters(PlayerHero hero)
        {
            Monster[] windTargets = Game.Monsters
                .Where(m => m.ShieldTimer == 0)
                .Where(m => m.DistanceTo(hero) < WindSpell.Range)
                .OrderBy(m => m.DistanceTo(hero))
                .ToArray();

            return new Func<bool>[]
            {
                () => hero.TryCastWind(windTargets.FirstOrDefault(), Game.OpponentBase, ref Mana)
            }.Concat(BaseDefense(hero)).ToArray();
        }

        private Func<bool>[] DefendAgainstOpponent(PlayerHero hero)
        {
            Hero opponent = Game.OpponentHeroes
                .Where(hero => !hero.IsControlled)
                .Where(hero => !Game.IsOnOpponentSide(hero))
                .OrderBy(hero => hero.DistanceTo(Game.PlayerBase))
                .FirstOrDefault();

            return new Func<bool>[]
            {
                () => hero.TryCastWind(opponent, Game.OpponentBase, ref Mana),
                () => hero.TryMove(opponent)
            }.Concat(BaseDefense(hero)).ToArray();
        }

        private Func<bool>[] BaseDefense(PlayerHero hero)
        {
            Monster shieldedTarget = Game.Monsters
                .Where(m => m.ShieldTimer > 0)
                .OrderBy(m => m.DistanceTo(Game.PlayerBase))
                .FirstOrDefault();

            Monster moveTarget = Game.Monsters
                .OrderBy(m => m.DistanceTo(Game.PlayerBase))
                .FirstOrDefault();

            return new Func<bool>[]
            {
                () => hero.TryMove(shieldedTarget),
                () => hero.TryMove(moveTarget),
                () => hero.TryMove(GetStartingPosition(hero)),
                () => hero.TryWait()
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

        private Func<bool>[] Harvest(PlayerHero hero)
        {
            Monster monster = Game.Monsters
                .Where(m => m.Position.DistanceTo(Game.PlayerBase) > Base.Visibility)
                .Where(m => m.Position.DistanceTo(Game.OpponentBase) > Base.Visibility)
                .OrderBy(m => m.Position.DistanceTo(hero))
                .FirstOrDefault();

            return new Func<bool>[]
            {
                () => hero.TryMove(monster),
                () => hero.TryMove(Game.MapCenter),
                () => hero.TryWait()
            };
        }
    }
}
