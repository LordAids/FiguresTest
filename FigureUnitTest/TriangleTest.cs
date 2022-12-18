using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureUnitTest
{
    public class TriangleTest
    {
        [TestCase(0,0,0)]
        [TestCase(-1,1,1)]
        [TestCase(1,-1,1)]
        [TestCase(1,-1,-1)]
        public void TriangleWithErrors(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void InitNotTriangleTest()
        {
            Assert.Catch<ArgumentException>(() => new Triangle(3, 4, 15));
        }

        [Test]
        public void TriangleCreateTest() 
        {
            double a = 3, b = 4, c = 5;

            Triangle triangle = new Triangle(a, b, c);

            Assert.NotNull(triangle);
            Assert.IsTrue(triangle.EdgeA - a == 0);
            Assert.IsTrue(triangle.EdgeB - b == 0);
            Assert.IsTrue(triangle.EdgeC - c == 0);
        }

        [Test]
        public void GetSquareTest()
        {
            double a = 3, b = 4, c = 5;
            double result = 6;
            Triangle triangle = new Triangle(a, b, c);
            var square = triangle?.GetSquare();
            Assert.NotNull(triangle);
            Assert.IsTrue((square.Value - result) == 0);
        }

        [TestCase(3, 4, 3, ExpectedResult = false)]
        [TestCase(5, 8, 9, ExpectedResult = false)]
        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(6, 8, 10, ExpectedResult = true)]
        public bool RightTriangle(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            return triangle.IsRightTriangle;
        }

    }
}
