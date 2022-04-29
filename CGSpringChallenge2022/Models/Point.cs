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

    public double DistanceTo(ILocation location)
        => location.Position.DistanceTo(this);
    public double DistanceTo(Point point)
        => Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));

    public override bool Equals(object obj)
        => obj is Point point &&
               X == point.X &&
               Y == point.Y;

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public static bool operator ==(Point a, Point b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Point a, Point b) => !(a == b);
}