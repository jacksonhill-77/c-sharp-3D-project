﻿using System;

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

        private double l1;
        private double l2;
        private double l3;

        public double Perimeter 
        {
            get { return Math.Round(l1 + l2 + l3, 2); }
        }

        public double Area 
        {
            get 
            {
                double s = (l1 + l2 + l3) / 2;
                return Math.Round
                (Math.Sqrt(s * 
                (s - l1) * 
                (s - l2) * 
                (s - l3)), 2);
            }
        }

        public Triangle(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            Line line1 = new Line(p1, p2);
            Line line2 = new Line(p2, p3);
            Line line3 = new Line(p3, p1);

            l1 = line1.CalculateLength();
            l2 = line2.CalculateLength();
            l3 = line3.CalculateLength();
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

