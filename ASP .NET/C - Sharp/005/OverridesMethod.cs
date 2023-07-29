using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    internal class RBI
    {
        public virtual void calculateInterest()
        {
            Console.WriteLine("Calculate interest from RBI.");
        }
    }
    class HDFC : RBI
    { 
        public override void calculateInterest()
        {
            Console.WriteLine("Calculate interest from HDFC.");
        }
    }
    class SBI : RBI
    {
        public override void calculateInterest()
        {
            Console.WriteLine("Calculate interest from SBI.");
        }
    }
    class ICICI : RBI
    {
        public override void calculateInterest()
        {
            Console.WriteLine("Calculate interest from ICICI.");
        }
    }
}

namespace Hospitals
{
    internal class Hospital
    {
        public virtual void hospitalDetails()
        {
            Console.WriteLine("Details of Hospital.");
        }
    }
    class Apollo : Hospital
    {
        public override void hospitalDetails()
        {
            Console.WriteLine("Details of Apollo Hospital.");
        }
    }
    class Wockhard : Hospital
    {
        public override void hospitalDetails()
        {
            Console.WriteLine("Details of Wockhard Hospital.");
        }
    }
    class Gokul : Hospital
    {
        public override void hospitalDetails()
        {
            Console.WriteLine("Details of Gokul Hospital.");
        }
    }
}