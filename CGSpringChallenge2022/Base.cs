public class Base
{
    public Base(int x, int y)
    {
        Position = new Point(x, y);
    }

    public Point Position { get; }
    public int Health { get; set; }
    public int Mana { get; set; }
}
