using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    public delegate int FactorialDelegate(int x);
    public class DelegateClass
    {
        public int calculateFactorial(int x)
        {
            if (x==0||x==1)
                return 1;

            return x * calculateFactorial(x-1);
        }
    }
}

namespace Trafiic
{
    public delegate string TrafficDelegate();
    internal class TrafficSignals
    {
        public string yellowSignal()
        {
            return "Yellow Light Signal To Get Ready.";
        }
        public string greenSignal()
        {
            return "Green Light Signal To Go.";
        }

        public string redSignal()
        {
            return "Red Light Signal To Stop.";
        }
    }
}
