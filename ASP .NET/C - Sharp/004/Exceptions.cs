using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004
{
    internal class Exceptions
    {
        public void divideByZeroException()
        {
            Console.Write("Enter the number : ");
            int numerator = Convert.ToInt32(Console.ReadLine());

            int denominator = 0;

            try
            {
                Console.WriteLine(numerator / denominator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void indexOutOfRangeException()
        {
            int[] arr = new int[5];

            for (int i=0; i<arr.Length; i++)
            {
                Console.Write($"Enter the value at {i} index : ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Enter the index : ");
            int index = Convert.ToInt32(Console.ReadLine());

            try
            {
                Console.WriteLine($"{arr[index]} value at {index} index.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void oddNumberException()
        {
            Console.Write("Enter the number : ");
            int number = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (number % 2 != 0)
                {
                    throw new Exception("Given number is not a even.");
                }
                else
                {
                    Console.WriteLine($"{number} is a even number.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
