using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001
{
    internal class Fundamentals
    {
        public void displayDetails ()
        {
            Console.WriteLine("Name : Uttam Nagvadiya.");
            Console.WriteLine("Address : Rajkot, Gujarat - INDIA.");
            Console.WriteLine("Contact no : 1234567890");               // Console.WriteLine() is print new line after display content.

            Console.Write("City : Rajkot ");                            // Console.Write() is not print new line after display content.
            Console.WriteLine("Gujarat");
        }

        public void getDetailsFromUser()
        {
            // Get two numbers and print it.
            Console.Write("Enter the first number : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number : ");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Number 1 = {0} \nNumber 2 = {1}\n", x, y);

            // Get name and country and print message.
            Console.Write("Enter your name : ");
            String name = Console.ReadLine();
            Console.Write("Enter your country name : ");
            String country = Console.ReadLine();
            
            Console.WriteLine("Hello, My name is {0}. I'm from {1}.", name, country);


            /*
                Console.ReadLine() is read the all characters from user input.          
                Console.Read() is it only accept single character from user input and return its ASCII Code.
                Console.ReadKey() is it read that which key is pressed by user and return its name.
                
                Ex : ConsoleKeyInfo  key = Console.ReadKey();
                     Console.WriteLine("You pressed {0}", key);         // U => You pressed U.   
            */
        }

        public void calculateArea()
        {
            // Area of rectangle
            Console.Write("Enter the length : ");
            double length = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the width : ");
            double width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Area of Rectangle = {0}\n", (length * width));

            // Area of circle
            Console.Write("Enter the radius : ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Area of Circle = {0}", (3.14 * radius * radius));
        }

        public void calculateTemperature()
        {
            // Celsius to Fahrenhit
            Console.Write("Enter the temperature in celsius : ");
            double celsius = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Fahrenhit = {0}\n", ((celsius * 9)/5)+32);

            // Fahrenhit to Celsius
            Console.Write("Enter the temperature in fahrenhit : ");
            double fahrenhit = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Celsius = {0}", ((fahrenhit - 32)*5)/9);
        }

        public void simpleIntrest()
        {
            Console.Write("Enter the principal amount : ");
            double principalAmount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the rate of intrest : ");
            double rateOfIntrest = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the number of periods : ");
            double numberOfPeriods = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Simple Intrest = {0}", (principalAmount * rateOfIntrest * numberOfPeriods) / 100);
        }

        public void simpleCalculator()
        {
            Console.Write("Enter the first number : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number : ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the operation you want perform : ");
            String op = Console.ReadLine();

            switch (op)
            {
                case "+":
                    Console.WriteLine("Addition = {0}", (x + y));
                    break;

                case "-":
                    Console.WriteLine("Addition = {0}", (x - y));
                    break;

                case "*":
                    Console.WriteLine("Addition = {0}", (x * y));
                    break;

                case "/":
                    Console.WriteLine("Addition = {0}", (x / y));
                    break;

                default:
                    Console.WriteLine("Please, Enter the valid operation.");
                    break;
            }
        }

        public void maximumNumber()
        {
            Console.Write("Enter the first number : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number : ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the third number : ");
            int z = Convert.ToInt32(Console.ReadLine());

            if (x > y)
            {
                if (x > z)
                {
                    Console.WriteLine("{0} is largest number.", x);
                }
                else
                {
                    Console.WriteLine("{0} is largest number.", z);
                }
            }
            else
            {
                if (y > z)
                {
                    Console.WriteLine("{0} is largest number.", y);
                }
                else
                {
                    Console.WriteLine("{0} is largest number.", z);
                }
            }

            /* Using ternary operator
            int max = (x > y)
                        ? (x > z) ? x : z
                        : (y > z) ? y : z;
            Console.WriteLine("{0} is largest number.", max);
            */

        }

        public void swapWithoutThirdVariable()
        {
            Console.Write("Enter the first number : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number : ");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("X = {0}\nY = {1}\n", x, y);

            x = x + y;
            y = x - y;
            x = x - y;

            Console.WriteLine("X = {0}\nY = {1}", x, y);
        }
    }
}
