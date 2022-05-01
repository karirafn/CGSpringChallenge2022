using System;

public abstract class Spell
{
    public Spell(string name, string parameters, int heroId, int range)
    {
        Name = name;
        Parameters = parameters;
        HeroId = heroId;
        Range = range;
    }

    public string Name { get; }
    public string Parameters { get; }
    public int HeroId { get; }
    public int Cost { get; } = 10;
    public int Range { get; }

    public bool TryCast(PlayerHero caster, Entity target, ref int mana, bool condition)
        => TryCast(ref mana, condition && caster.DistanceTo(target) <= Range);

    public bool TryCast(ref int mana, bool condition)
    {
        if (condition && mana >= Cost)
        {
            Console.WriteLine($"SPELL {Name} {Parameters} {Name[0]}{HeroId}");
            mana -= Cost;

            return true;
        }

        return false;
    }
}
