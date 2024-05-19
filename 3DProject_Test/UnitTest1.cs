using Project;
using NUnit.Framework;

namespace Project.Tests
{   
    [TestFixture]
    public class LineTests
    {
        private Point p1;
        private Point p2;
        private Point p3;
        private Point p4;
        private Point p5;
        private Point p6;
        private Point p7;
        private Point p8;

        [SetUp]
        public void Setup()
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

        [Test]
        public void CalculateLength_OrdinaryPoints_ReturnsCorrectDistance()
        {
            Line line = new Line(p1, p2);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(8.66).Within(0.01));
        }

        [Test]
        public void CalculateLength_NegativeCoordinates_ReturnsCorrectDistance()
        {
            Line line = new Line(p3, p4);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(1.73).Within(0.01));
        }

        [Test]
        public void CalculateLength_SameCoordinates_ReturnsZero()
        {
            Line line = new Line(p5, p6);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(0.00).Within(0.01));
        }

        [Test]
        public void CalculateLength_LargeNumbers_ReturnsCorrectDistance()
        {
            Line line = new Line(p7, p8);
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(8616.84).Within(0.01));
        }
    }
}

