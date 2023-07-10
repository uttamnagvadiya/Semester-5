using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002
{
    internal class Fundamentals
    {
        public void bodyMassIndex()
        {
            Console.Write("Enter the weight in pound : ");
            double weight = Convert.ToDouble(Console.ReadLine()) * 0.4536;
            Console.Write("Enter the hieght in inch : ");
            double height = Convert.ToDouble(Console.ReadLine()) * 0.0254;

            double bmi = weight / (height * height);

            Console.WriteLine("BMI = {0}", bmi);
        }
        public void calculatePercentage()
        {
            Console.Write("Enter the mark of ASP.NET : ");
            int dotnet = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the mark of Software Engineering : ");
            int soft_engin = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the mark of Computer Network : ");
            int comp_net = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the mark of Data Mining : ");
            int data_mining = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the mark of Accounting : ");
            int accounting  = Convert.ToInt32(Console.ReadLine());

            double percentage = (dotnet + soft_engin + comp_net + data_mining + accounting) / 5;

            Console.WriteLine("Percentage = {0}%", percentage);

            if (percentage > 85.0)
            {
                Console.WriteLine("You are in Distinct Class.");
            }
            else if (percentage <= 85.0 && percentage > 70.0)
            {
                Console.WriteLine("You are in First Class");
            }
            else if (percentage <= 70.0 && percentage > 55.0)
            {
                Console.WriteLine("You are in Second Class");
            }
            else if (percentage <= 55.0 && percentage > 40.0)
            {
                Console.WriteLine("You are in Third Class");
            }
            else
            {
                Console.WriteLine("You are Failed.");
            }
        }

        public void checkPrimeNumber()
        {
            Console.Write("Enter the number : ");
            int number = Convert.ToInt32(Console.ReadLine());

            bool flag = true;

            for (int i=2; i<(number/2); i++)
            {
                if (number % i == 0)
                { 
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("{0} is prime number.", number);
            }
            else
            {
                Console.WriteLine("{0} is not prime number.", number);
            }
        }

        public void checkLeapYear()
        {
            Console.Write("Enter the year : ");
            int year = Convert.ToInt32(Console.ReadLine());

            if (year % 4 == 0 && year % 100 != 0)
            {
                Console.WriteLine("{0} is a leap year.");
            }
            else if (year % 400 == 0)
            {
                Console.WriteLine("{0} is a leap year.");
            }
            else
            {
                Console.WriteLine("{0} is not a leap year.");
            }
        }

        public void fibonacciSeries()
        {
            Console.Write("Enter the number of terms : ");
            int terms = Convert.ToInt32(Console.ReadLine());

            int x = 0, y = 1;

            for (int i=0; i<terms; i++)
            {
                Console.Write(x + " ");
                int temp = x + y;
                x = y;
                y = temp;
            }
        }

        public void decimalToBinary()
        {
            Console.Write("Enter the decimal number : ");
            int decimalNumber = Convert.ToInt32(Console.ReadLine());

            String binaryNumber = "";

            while (decimalNumber != 0)
            {
                int remainder = decimalNumber % 2;
                binaryNumber += remainder.ToString();
                decimalNumber = Convert.ToInt32(decimalNumber / 2);
            }

            for (int i=binaryNumber.Length-1; i>=0; i--)
            {
                Console.Write(binaryNumber[i]);
            }
        }

        public void calculate_nPr()
        {
            Console.Write("Enter the N : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the R : ");
            int r = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0}P{1} = {2}", n, r, (factorial(n) / factorial(n - r)));
        }

        public int factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }
    }
}
