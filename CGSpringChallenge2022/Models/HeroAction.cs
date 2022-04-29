using System;

namespace CGSpringChallenge2022
{
    public interface IHeroAction
    {
        public void Act();
    }

    public class HeroAction : IHeroAction
    {
        private HeroAction(string name, string parameters, int heroId)
        {
            Name = name;
            Parameters = parameters;
            HeroId = heroId;
        }

        protected string Name { get; }
        public string Parameters { get; }
        public int HeroId { get; }

        public virtual void Act() => Console.WriteLine(string.IsNullOrEmpty(Parameters) ? $"{Name} {Name[0]}{HeroId}" : $"{Name} {Parameters} {Name[0]}{HeroId}");

        public class Spell : HeroAction
        {
            public const int Cost = 10;

            public Spell(string name, string parameters, int heroId) : base(name, parameters, heroId) { }

            public override void Act() => Console.WriteLine($"SPELL {Name} {Parameters} {Name[0]}{HeroId}");
        }

        public class WaitAction : HeroAction
        {
            public WaitAction(int heroId) : base("WAIT", string.Empty, heroId) { }
        }

        public class MoveAction : HeroAction
        {
            public MoveAction(string parameters, int heroId) : base("MOVE", parameters, heroId) { }
        }

        public class WindSpell : Spell
        {
            public const int Range = 1280;
            public const int Push = 2200;
            public WindSpell(string parameters, int heroId) : base("WIND", parameters, heroId) { }
        }

        public class ShieldSpell : Spell
        {
            public const int Range = 2200;
            public ShieldSpell(string parameters, int heroId) : base("SHIELD", parameters, heroId) { }
        }

        public class ControlSpell : Spell
        {
            public const int Range = 2200;
            public ControlSpell(string parameters, int heroId) : base("CONTROL", parameters, heroId) { }
        }
    }
}
