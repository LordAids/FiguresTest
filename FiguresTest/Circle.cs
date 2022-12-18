using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresTest
{
    public class Circle : IFigure
    {
        public double radius;
        public Circle(double radius) 
        {
            if (radius <= 0)
                throw new ArgumentException("Invalid circle radius", nameof(radius));
            this.radius = radius; 
        }
        public double GetSquare()
        {
            return Math.PI * Math.Pow(radius, 2d);
        }
    }
}
