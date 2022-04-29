public class ControlSpell : Spell
{
    public new const int Range = 2200;
    public ControlSpell(string parameters, int heroId) : base("CONTROL", parameters, heroId, Range) { }
}
