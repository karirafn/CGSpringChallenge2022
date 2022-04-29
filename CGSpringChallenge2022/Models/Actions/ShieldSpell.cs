public class ShieldSpell : Spell
{
    public new const int Range = 2200;
    public ShieldSpell(string parameters, int heroId) : base("SHIELD", parameters, heroId, Range) { }
}
