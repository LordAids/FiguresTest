using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresTest
{
    public class Triangle : IFigure
    {
        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }

        private readonly Lazy<bool> _isRightTriangle;
        public bool IsRightTriangle => _isRightTriangle.Value;
        public Triangle( double edgeA, double edgeB, double edgeC) 
        {
            if (edgeA <= 0)
                throw new ArgumentException("Side specified incorrectly", nameof(edgeA));

            if (edgeB <= 0)
                throw new ArgumentException("Side specified incorrectly", nameof(edgeB));

            if (edgeC <= 0)
                throw new ArgumentException("Side specified incorrectly", nameof(edgeC));

            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            var perimeter = edgeA + edgeB + edgeC;
            if (perimeter - (2 * maxEdge) <= 0)
                throw new ArgumentException("The longest side of the triangle must be less than the sum of the other sides");

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }
        private bool GetIsRightTriangle()
        {
            double maxEdge = EdgeA, b = EdgeB, c = EdgeC;
            if (b - maxEdge > 0)
                Swap(ref maxEdge, ref b);

            if (c - maxEdge > 0)
                Swap(ref maxEdge, ref c);

            return Math.Pow(maxEdge, 2) == Math.Pow(b, 2) + Math.Pow(c, 2);
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public double GetSquare()
        {
            var hP = (EdgeA + EdgeB + EdgeC) / 2d; //полупериметр 
            var square = Math.Sqrt(
                hP
                * (hP - EdgeA)
                * (hP - EdgeB)
                * (hP - EdgeC)
            );

            return square;
        }
    }
}
