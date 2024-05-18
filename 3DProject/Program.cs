using System;

namespace Project 
{
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
            return $"({X}, {Y}, {Z})";
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
            double distanceX = Math.Pow((pointA.X - pointB.X), 2);
            double distanceY = Math.Pow((pointA.Y - pointB.Y), 2);
            double distanceZ = Math.Pow((pointA.Z - pointB.Z), 2);
            double result = Math.Round(Math.Sqrt(distanceX + distanceY + distanceZ), 2);
            Console.WriteLine($"The distance between Point A and Point B is {result}.");
            return result;
        }
    }

    class Program 
    {
        static void Main()
        {
            Point pointA = new Point(4, 10, 3);
            Point pointB = new Point(3, 5, 10);

            Line line = new Line(pointA, pointB);
            line.CalculateLength();
        }
    }
}
