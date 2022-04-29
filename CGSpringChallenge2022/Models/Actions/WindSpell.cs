public class WindSpell : Spell
{
    public new const int Range = 1280;
    public const int Push = 2200;
    public WindSpell(string parameters, int heroId) : base("WIND", parameters, heroId, Range) { }
}
