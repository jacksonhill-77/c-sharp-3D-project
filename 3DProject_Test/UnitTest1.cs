using Project;
using NUnit.Framework;

namespace Project.Tests
{   

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
                new Point(3000,10000,5000)
            };
        }
    }

    [TestFixture]
    public class LineTests
    {
        private Point[] points;

        [SetUp]
        public void Setup()
        {
            points = PointUtility.GetPoints()
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

        [SetUp]
        public void SetUp()
        {
            this.p1 = new Point(5,5,5);
            this.p2 = new Point(10,10,10);
            this.p3 = new Point(-3,-8,-5);
            this.p4 = new Point(-2,-7,-4);
            this.p5 = new Point(2,2,2);
            this.p6 = new Point(2,2,2);
            this.p7 = new Point(1000,2000,2500);
            this.p8 = new Point(3000,10000,5000);
        }
    }
}

