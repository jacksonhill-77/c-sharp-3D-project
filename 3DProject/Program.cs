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
            double distanceX = Math.Pow(pointA.X - pointB.X, 2);
            double distanceY = Math.Pow(pointA.Y - pointB.Y, 2);
            double distanceZ = Math.Pow(pointA.Z - pointB.Z, 2);
            return Math.Sqrt(distanceX + distanceY + distanceZ);
        }
    }

    public class Triangle 
    {
        private Point p1;
        private Point p2;
        private Point p3;

        private Line l1;
        private Line l2;
        private Line l3;

        public double Perimeter 
        {
            get { return Math.Round(l1.CalculateLength() + l2.CalculateLength() + l3.CalculateLength(), 2); }
        }

        public double Area 
        {
            get 
            {
                double s = (l1.CalculateLength() + l2.CalculateLength() + l3.CalculateLength()) / 2;
                return Math.Round
                (Math.Sqrt(s * 
                (s - l1.CalculateLength()) * 
                (s - l2.CalculateLength()) * 
                (s - l3.CalculateLength())), 2);
            }
        }

        public Triangle(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            l1 = new Line(p1, p2);
            l2 = new Line(p2, p3);
            l3 = new Line(p3, p1);
        }

    }

    class Program 
    {
        static void Main()
        {
            Point p1 = new Point(4, 10, 3);
            Point p2 = new Point(3, 5, 10);
            Point p3 = new Point(5, 10, 25);

            Triangle triangle = new Triangle(p1, p2, p3);
            Console.WriteLine($"The perimeter of your triangle is {triangle.Perimeter} units.");
            Console.WriteLine($"The area of your triangle is {triangle.Area} units squared.");
        }
    }
}

