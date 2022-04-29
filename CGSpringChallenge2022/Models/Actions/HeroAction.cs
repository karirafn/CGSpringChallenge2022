using System;

public abstract class HeroAction
{
    public HeroAction(string name, string parameters, int heroId)
    {
        Name = name;
        Parameters = parameters;
        HeroId = heroId;
    }

    protected string Name { get; }
    public string Parameters { get; }
    public int HeroId { get; }

    public virtual bool TryAct(bool condition = true)
    {
        if (condition)
        {
            Console.WriteLine(string.IsNullOrEmpty(Parameters) ? $"{Name} {Name[0]}{HeroId}" : $"{Name} {Parameters} {Name[0]}{HeroId}");
            
            return true;
        }

        return false;
    }
}
