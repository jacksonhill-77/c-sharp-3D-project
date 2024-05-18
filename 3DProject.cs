using System;

public class Point 
{
    private double x;
    private double y;
    private double z;

    public Point(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double X 
    {
        get { return x; }
        set { x = value; }
    }

        public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double Z
    {
        get { return z; }
        set { z = value; }
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})"
    }
}

public class Line 
{
    private Point pointA;
    private Point pointB;

    public Line(Point pointA, Point pointB)
    {
        this.pointA = pointA;
        this.pointB = pointB;
    }

    public double CalculateLength()
    {
        double distanceX = Math.pow(pointA.X - pointB.X);
        double distanceY = Math.pow(pointA.Y - pointB.Y);
        double distanceZ = Math.pow(pointA.Z - pointB.Z);
        double result = Math.Sqrt(distanceX + distanceY + distanceZ);
        Console.WriteLine(result);
        return result
    }
}

Point pointA = new Point(4, 10, 3);
Point pointB = new Point(3, 5, 10);

Line line = new Line(pointA, pointB);
line.CalculateLength();



