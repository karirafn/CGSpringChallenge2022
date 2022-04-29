using CGSpringChallenge2022.Models;
using System.Collections.Generic;
using System.Linq;
using static CGSpringChallenge2022.HeroAction;

namespace CGSpringChallenge2022.Strategies
{
    public class WindMonstersIntoEnemyBase : StrategyBase, IStrategy
    {
        public WindMonstersIntoEnemyBase(Game game) : base(game)
        {
        }

        public void PerformActions()
        {
            PerformAction(() => Defend(Heroes[0]));
            PerformAction(() => Attack(Heroes[1]));
            PerformAction(() => Defend(Heroes[2]));
        }

        private void Defend(PlayerHero hero)
        {
            Hero opponent = Game.OpponentHeroes
                .Where(h => !h.IsControlled)
                .Where(h => h.DistanceTo(hero) < ControlSpell.Range)
                .FirstOrDefault();

            Monster shieldedTarget = Game.Monsters
                .Where(m => m.ShieldTimer > 0)
                .OrderBy(m => m.DistanceTo(Game.PlayerBase))
                .FirstOrDefault();

            IEnumerable<Monster> windTargets = Game.Monsters
                .Where(m => m.ShieldTimer == 0)
                .Where(m => m.DistanceTo(hero) < WindSpell.Range);

            Monster moveTarget = Game.Monsters
                .OrderBy(e => e.DistanceTo(Game.PlayerBase))
                .Where(m => m.DistanceTo(Game.PlayerBase) < Base.Visibility)
                .FirstOrDefault();

            bool highAlert = moveTarget != null && moveTarget.DistanceTo(Game.PlayerBase) < 2000;

            if (!highAlert && opponent != null)
            {
                hero.Control(opponent.Id, Game.OpponentBase);
                Mana -= Spell.Cost;
            }
            else if (Mana > Spell.Cost && (opponent != null || windTargets.Count() > 2 || windTargets.Any(m => m.IsNearBase)))
            {
                hero.Wind(Game.OpponentBase);
                Mana -= Spell.Cost;
            }
            else if (shieldedTarget != null)
            {
                hero.Move(shieldedTarget);
            }
            else if (moveTarget != null)
            {
                hero.Move(moveTarget);
            }
            else
            {
                MoveToStartingPosition(hero);
            }

            ActionsPerformed++;
        }

        private void Attack(PlayerHero hero)
        {
            Monster spellTarget = Game.Monsters
                .Where(m => m.Threat != ThreatType.OpponentBase)
                .Where(m => m.DistanceTo(hero) <= WindSpell.Range)
                .FirstOrDefault();

            Monster moveTarget = Game.Monsters
                .Where(m => m.Threat != ThreatType.OpponentBase)
                .Where(m => IsOnOpponentSide(m))
                .OrderBy(m => m.DistanceTo(Game.OpponentBase))
                .FirstOrDefault();

            System.Console.Error.WriteLine($"Is player one: {Game.IsPlayerOne}");
            System.Console.Error.WriteLine($"Is on opponent half: {IsOnOpponentSide(hero)}");

            if (!IsOnOpponentSide(hero))
            {
                hero.Move(new Point(Game.MapCenter.X + 10, Game.MapCenter.Y));
            }
            else if (Mana > Spell.Cost && spellTarget != null)
            {
                hero.Wind(Game.OpponentBase);
                Mana -= Spell.Cost;
            }
            else if (moveTarget != null)
            {
                hero.Move(moveTarget);
            }
            else if (hero.Position != Game.MapCenter)
            {
                hero.Move(Game.MapCenter);
            }
            else if (Game.Monsters.Any())
            {
                hero.Move(Game.Monsters.OrderBy(m => m.DistanceTo(hero)).First());
            }
            else
            {
                hero.Wait();
            }

            ActionsPerformed++;
        }

        private void Harvest(PlayerHero hero)
        {
            Monster monster = Game.Monsters
                .Where(m => m.Position.DistanceTo(Game.PlayerBase) > Base.Visibility)
                .Where(m => m.Position.DistanceTo(Game.OpponentBase) > Base.Visibility)
                .OrderBy(m => m.Position.DistanceTo(hero))
                .FirstOrDefault();

            if (monster is null)
                hero.Move(Game.MapCenter);
            else
                hero.Move(monster);

            ActionsPerformed++;
        }
    }
}
