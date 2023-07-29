using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004
{
    interface CalculateInterface
    {
        double addition(double x, double y);
        double subtractition(double x, double y);
    }

    class Result : CalculateInterface
    {
        public double addition(double x, double y)
        {
            return (x + y);
        }
        public double subtractition(double x, double y)
        {
            return (x - y);
        }
    }
}
