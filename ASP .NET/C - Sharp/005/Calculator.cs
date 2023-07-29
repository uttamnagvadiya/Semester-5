using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    public delegate T CalculatorDelegate <T>(T num1, T num2);
    internal class Calculator
    {
        public int Addition(int num1, int num2)
        {
            return (num1 + num2);
        }
        public int Substraction(int num1, int num2)
        {
            return (num1 - num2);
        }
        public double Multiplication(double num1, double num2)
        {
            return (num1 * num2);
        }
        public double Division(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return (num1 / num2);
        }
    }
}
