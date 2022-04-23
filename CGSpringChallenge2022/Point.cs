using System;

public struct Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public double DistanceTo(IPositionable p)
        => Math.Sqrt(Math.Pow(p.Position.X - X, 2) + Math.Pow(p.Position.Y - Y, 2));
}