using Project;
using NUnit.Framework;

namespace Project.Tests
{   
    [TestFixture]
    public class LineTests
    {
        private Line line;
        private Point pointA;
        private Point pointB;

        [SetUp]
        public void Setup()
        {
            this.pointA = new Point(5,5,5);
            this.pointB = new Point(10,10,10);

            line = new Line(pointA, pointB);
        }

        [Test]
        public void CalculateLength_ReturnsCorrectDistance()
        {
            double length = line.CalculateLength();
            Assert.That(length, Is.EqualTo(8.66).Within(0.01));
        }
    }
}

