using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004
{
    internal class StringMethods
    {
        string name = " Darshan University   ";

        public void methodsOfString()
        {
            Console.WriteLine($"Concat two string = {string.Concat(name, ", Rajkot    ")}");
            Console.WriteLine($"Check 'University' is present or not = {name.Contains("University")}");
            Console.WriteLine($"Count of elements = {name.Count()}");
            Console.WriteLine($"Index of 'U' = {name.IndexOf("U")}");
            Console.WriteLine($"Insert char. at specific index = {name.Insert(19, ", Hadala")}");
            Console.WriteLine($"Last index of char. 'v' = {name.LastIndexOf("v")}");
            Console.WriteLine($"Length of string = {name.Length}");
            Console.WriteLine($"Max element in string = {name.Max()}");
            Console.WriteLine($"Min element in string = {name.Min()}");
            Console.WriteLine($"Repalce charcters = {name.Replace("University", "Institute")}");
            Console.WriteLine($"Remove element on specific index = {name.Remove(6, 1)}");
            string[] strs = name.Split(" ");
            Console.Write($"List of string using split = ");
            foreach (string item in strs)
            {
                Console.Write($"{item} | ");
            }
            Console.WriteLine();
            Console.WriteLine($"Substring of string = {name.Substring(8, 9)}");
            Console.WriteLine($"Trimmed string = {name.Trim()}");
            Console.WriteLine($"String in upper case = {name.ToUpper()}");
            Console.WriteLine($"String in lower case = {name.ToLower()}");
        }

        public void changeCases(string str)
        {
            string caseChangeString = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLower(str[i]))
                {
                    caseChangeString += char.ToUpper(str[i]);
                }
                else
                {
                    caseChangeString += char.ToLower(str[i]);
                }
            }

            Console.WriteLine($"Original = {str}\nChanged = {caseChangeString}");
        }

        public void findLongestWord(string str)
        {
            string longestWord = string.Empty;
            string[] strs = str.Split(" ");
            foreach (string item in strs)
            {
                if (longestWord.Length < item.Length)
                {
                    longestWord = item;
                }
            }
            Console.WriteLine($"Longest word in the string = {longestWord}");
        }

        public void changedCaseOfCharacter()
        {
            Console.Write("Enter a character : ");
            char inputChar = Console.ReadKey().KeyChar;

            char resultChar = changeCase(inputChar);
            Console.WriteLine($"\nCharacter with changed case: {resultChar}");
        }

        public char changeCase(char inputChar)
        {
            if (char.IsLower(inputChar))
                return char.ToUpper(inputChar);
            else if (char.IsUpper(inputChar))
                return char.ToLower(inputChar);
            else
                return inputChar;
        }
    }
}
