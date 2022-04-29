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

    public double DistanceTo(ILocation p)
        => Math.Sqrt(Math.Pow(p.Position.X - X, 2) + Math.Pow(p.Position.Y - Y, 2));

    public override bool Equals(object obj)
        => obj is Point point &&
               X == point.X &&
               Y == point.Y;

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public static bool operator ==(Point a, Point b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Point a, Point b) => !(a == b);
}