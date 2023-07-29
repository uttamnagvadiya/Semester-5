using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004
{
    public abstract class Sum
    {
        public abstract int sumOfTwoNumbers(int x, int y);
        public abstract int sumOfThreeNumbers(int x, int y, int z);
    }

    public class Calculate : Sum
    {
        public override int sumOfTwoNumbers(int x, int y)
        {
            return (x+y);
        }
        public override int sumOfThreeNumbers(int x, int y, int z)
        {
            return (x+y+z);
        }
    }
}
