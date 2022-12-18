using FiguresTest;

namespace FigureUnitTest
{
    public class CircleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroRadius()
        {
            Assert.Catch<ArgumentException>(() => new Circle(0));
        }

        [Test]
        public void NegativeRadius()
        {
            Assert.Catch<ArgumentException>(() => new Circle(-5));
        }

        [Test]
        public void GetCircleSquare()
        {
            double radius = 5;
            Circle circle = new Circle(radius);
            double expectedValue = Math.PI * Math.Pow(radius, 2d);
            Assert.IsTrue(Math.Abs(circle.GetSquare() - expectedValue) == 0);
        }
    }
}