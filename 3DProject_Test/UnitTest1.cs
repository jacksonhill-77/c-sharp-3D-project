using Project;
using NUnit.Framework;
using System.Runtime;

namespace Project.Tests
{   

    [TestFixture]
    public class LineTests
    {
        private Point[] points;

        [SetUp]
        public void Setup()
        {
            points = PointUtility.GetPoints();
        }

        [Test]
        public void CalculateLength_OrdinaryPoints_ReturnsCorrectDistance()
        {
            Line line = new Line(points[0], points[1]);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(8.66).Within(0.01));
        }

        [Test]
        public void CalculateLength_NegativeCoordinates_ReturnsCorrectDistance()
        {
            Line line = new Line(points[2], points[3]);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(1.73).Within(0.01));
        }

        [Test]
        public void CalculateLength_SameCoordinates_ReturnsZero()
        {
            Line line = new Line(points[4], points[5]);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(0.00).Within(0.01));
        }

        [Test]
        public void CalculateLength_LargeNumbers_ReturnsCorrectDistance()
        {
            Line line = new Line(points[6], points[7]);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(8616.84).Within(0.01));
        }
    }

    [TestFixture]
    public class TriangleTests 
    {

        private Point[] points;

        [SetUp]
        public void SetUp()
        {
            points = PointUtility.GetPoints();
        }

        [Test]
        public void CalculatePerimeter_OrdinaryNumbers_ReturnsCorrectPerimeter()
        {
            Triangle triangle = new Triangle(points[0], points[1], points[8]);
            Assert.That(triangle.Perimeter, Is.EqualTo(24.25).Within(0.01));
        }

        [Test]
        public void CalculatePerimeter_LargeNumbers_ReturnsCorrectPerimeter()
        {
            Triangle triangle = new Triangle(points[6], points[7], points[11]);
            Assert.That(triangle.Perimeter, Is.EqualTo(52574.22).Within(0.01));
        }

        [Test]
        public void CalculateArea_OrdinaryNumbers_ReturnsCorrectArea()
        {
            Triangle triangle = new Triangle(points[0], points[2], points[3]);
            Assert.That(triangle.Area, Is.EqualTo(3.08).Within(0.01));
        }

        [Test]
        public void CalculateArea_LargeNumbers_ReturnsCorrectArea()
        {
            Triangle triangle = new Triangle(points[6], points[7], points[11]);
            Assert.That(triangle.Area, Is.EqualTo(68155153.87).Within(0.1));
        }
    }

    [TestFixture]
    public class PointCollectionTests
    {

        [Test]
        public void AddPoint_NewPoint_PointIsAdded() 
        {
            PointCollection pointCollection = new PointCollection();
            pointCollection.AddPoint(10, 5, 7);
            Point p = pointCollection.GetAllPoints()[0];
            Assert.That((p.X, p.Y, p.Z), Is.EqualTo((10, 5, 7)));
        }

        // MethodName_StateUnderTest_ExpectedBehaviour
        [Test]
        public void RemovePoint_ExistingPoint_PointIsRemoved() 
        {
            PointCollection pointCollection = new PointCollection();
            pointCollection.AddPoint(10, 5, 7);
            pointCollection.RemovePoint(10, 5, 7);
            List<Point> points = pointCollection.GetAllPoints();
            Assert.That(points.Count, Is.EqualTo(0));
        }

        [Test]
        public void FindPoint_ExistingPoint_ReturnsCorrectPoint() 
        {
            PointCollection pointCollection = new PointCollection();
            pointCollection.AddPoint(10, 5, 7);
            pointCollection.AddPoint(2, 4, 5);
            Point? p = pointCollection.FindPoint(2, 4, 5);
            Assert.That((p.X, p.Y, p.Z), Is.EqualTo((2, 4, 5)));
        }

        [Test]
        public void FindPoint_NoPoints_ReturnsNull() 
        {
            PointCollection pointCollection = new PointCollection();
            pointCollection.AddPoint(10, 5, 7);
            pointCollection.RemovePoint(10, 5, 7);
            Point? p = pointCollection.FindPoint(10, 5, 7);
            Assert.That(p, Is.EqualTo(null));
        }

        [Test]
        public void GetAllPoints_MultiplePoints_ReturnsPoints() 
        {
            PointCollection pointCollection = new PointCollection();
            pointCollection.AddPoint(10, 5, 7);
            pointCollection.AddPoint(2, 4, 5);
            pointCollection.AddPoint(5,8,3); 
            List<Point> points = pointCollection.GetAllPoints();
            Assert.That((points[0].X, points[1].Y, points[2].Z), Is.EqualTo((10, 4, 3)));
        }

        [Test]
        public void WriteToFile_PointArray_AddsValuesToColumns()
        {
            PointCollection pointCollection = new PointCollection();
            Point[] testPoints = PointUtility.GetPoints();

            foreach (Point p in testPoints)
            {
                pointCollection.AddPointObject(p);
            }

            pointCollection.WriteToFile("./points.csv");
            pointCollection.ReadPointsFromFile("./points.csv");  

            List<Point> points = pointCollection.GetAllPoints();

            Assert.That((points[0].X, points[0].Y, points[0].Z), Is.EqualTo((5, 5, 5)));
        }

        [Test]
        public void ReadFromFile_NoFileExists_CatchExceptionWorks()
        {
            PointCollection pointCollection = new PointCollection();

            var ex = Assert.Throws<FileNotFoundException>(() => 
            pointCollection.ReadPointsFromFile("./imaginary_points.csv"));
        }
    }
}

