using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004
{
    interface ShapeInterface
    {
        double areaOfCircle(double radius);
        double areaOfSquare(double length);
        double areaOfTriangle(double baseOfTriangle, double height);
    }

    class Shape : ShapeInterface
    {
        public double areaOfCircle(double radius)
        {
            return (3.14 * radius * radius);
        }

        public double areaOfSquare(double length)
        {
            return (length * length);
        }

        public double areaOfTriangle(double baseOfTriangle, double height)
        {
            return (0.5 * baseOfTriangle * height);
        }

    }
}
