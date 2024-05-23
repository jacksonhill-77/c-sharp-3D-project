using System;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

    public static class PointUtility
    {
        public static Point[] GetPoints()
        {
            return new Point[]
            {
                new Point(5,5,5),
                new Point(10,10,10),
                new Point(-3,-8,-5),
                new Point(-2,-7,-4),
                new Point(2,2,2),
                new Point(2,2,2),
                new Point(1000,2000,2500),
                new Point(3000,10000,5000),
                new Point(3,3,3),
                new Point(-10,12,-14),
                new Point(2,2,2),
                new Point(20000, 15000, 12000)
            };
        }

        public static void WritePointToConsole(Point p)
        {
            Console.WriteLine($"{p.X}, {p.Y}, {p.Z}");
        }
    }

    public class PointCollection
    {
        private List<Point> pointList;

        public PointCollection()
        {
            pointList = new List<Point>();
        }

        public void AddPointObject(Point p)
        {
            pointList.Add(p);
        }

        public void AddPoint(double x, double y, double z) 
        {
            pointList.Add(new Point(x, y, z));
        }

        public Point? FindPoint(double x, double y, double z)
        {

            foreach (Point p in pointList) 
            {   
                if (p.X == x && p.Y == y && p.Z == z)
                {
                    return p;
                }
            }
            return null;
        }

        public void RemovePoint(double x, double y, double z)
        {   
            int index = -1;

            foreach (Point p in pointList)
            {
                index++;
                if (p.X == x && p.Y == y && p.Z == z)
                {   
                    break;
                }
            }
            
            if (0 <= index && index < pointList.Count) 
            {
                pointList.RemoveAt(index);
            }
        }

        public List<Point> GetAllPoints()
        {
            return pointList;
        }

        public void WriteToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Point p in pointList)
                {   
                    writer.WriteLine(string.Join(",", $"{p.X.ToString()}, {p.Y.ToString()}, {p.Z.ToString()}"));
                }
            }
        }

        private void addPointsFromLinesToCollection(string filePath)
        {
            var lines = File.ReadLines(filePath);

            foreach (var line in lines) 
            {
                string[] cols = line.Split(',');

                double x = int.Parse(cols[0].Trim());
                double y = int.Parse(cols[1].Trim());
                double z = int.Parse(cols[2].Trim());

                Point p = new Point(x, y, z);

                pointList.Add(p);
            }
        }

        public void ReadPointsFromFile(string filePath)
        {

            if (File.Exists(filePath)) 
            {
                addPointsFromLinesToCollection(filePath);
            }
            else
            {
                throw new FileNotFoundException($"The file '{filePath}' was not found.");
            }
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

        private double perimeter;
        private double area;

        public double Perimeter 
        {
            get { return Math.Round(perimeter, 2); }
        }

        public double Area 
        {
            get { return area; }
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

            perimeter = l1 + l2 + l3;

            double s = perimeter / 2;
            area = Math.Round
                (Math.Sqrt(s * 
                (s - l1) * 
                (s - l2) * 
                (s - l3)), 2);
        }

    }

    class Program 
    {
        static void Main()
        {    
        }
    }
}

