using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    internal class OperatorOverloading
    {
        int a, b, c;

        public OperatorOverloading(int x, int y, int z)
        {
            a= x; b = y; c= z;
        }

        public static OperatorOverloading operator ++(OperatorOverloading op)
        {
            op.a--;
            op.b--;
            op.c--;

            return op;
        }

        public void display()
        {
            Console.WriteLine($"{a} - {b} - {c}");
        }
    }
}
