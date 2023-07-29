using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollectionClasses
{
    internal class ArrayListDemo
    {
        ArrayList array = new ArrayList();
        
        public void arraListFunctions()
        {
            // Insert an elements using Add(Object value) function in ArrayList.
            for (int i = 10; i <= 100; i+=10)
            {
                array.Add(i);
            }

            // Display elements of the ArrayList.
            foreach (var item in array)
            {
                Console.Write($"{item} | ");
            }

            // Removes specific objects using Remove(Object obj) function from ArrayList.
            array.Remove(40);
            
            // Removes specific elements by indexes using RemoveAt(int index) function from ArrayList. 
            array.RemoveAt(4);

            // Removes elements by range using RemoveRange(int index, int count) function from ArrayList.
            array.RemoveRange(2, 4);

            // Check whether an element is present or not in the ArrayList.
            array.Contains(20);

            // Count the number of elements are actually present in the ArrayList.
            int count = array.Count;

            // Return the index of specified object of ArrayList.
            array.IndexOf(20);

            // Insert the element at the specified index into the ArrayList.
            array.Insert(2, 30);

            // Sort the ArrayList
            array.Sort();

            // Clear all the elements from the ArrayList.
            array.Clear();
        }
    }

    internal class StackDemo
    {
        Stack stk = new Stack();

        public void stackFunctions()
        {
            // Insert an elements using Push(Object value) function at the top of the Stack.
            for (int i = 10; i <= 100; i += 10)
            {
                stk.Push(i);
            }

            // Display elements of the Stack.
            foreach (var item in stk)
            {
                Console.Write($"{item} | ");
            }

            // Remove and return the object at the top of the Stack.
            stk.Pop();

            // Return the object without removing at the top of the Stack.
            stk.Peek();

            // Check whether an element is present or not in the Stack.
            stk.Contains(20);

            // Count the number of elements are actually present in the Stack.
            int count = stk.Count;

            // Clear all the elements from the Stack.
            stk.Clear();
        }
    }

    internal class QueueDemo
    {
        Queue que = new Queue();

        public void queueFunctions()
        {
            // Insert an elements using Enqueue(Object value) function at the end of the Queue.
            for (int i = 10; i <= 100; i += 10)
            {
                que.Enqueue(i);
            }

            // Display elements of the Queue.
            foreach (var item in que)
            {
                Console.Write($"{item} | ");
            }

            // Remove and return the object at the beginning of the Queue.
            que.Dequeue();

            // Return the object without removing at the top of the Queue.
            que.Peek();

            // Check whether an element is present or not in the Queue.
            que.Contains(20);

            // Count the number of elements are actually present in the Queue.
            int count = que.Count;

            // Clear all the elements from the Queue.
            que.Clear();
        }
    }
    
    internal class DictionaryDemo
    {
        Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();

        public void dictionaryFunctions()
        {
            // Insert value with specified key in the Dictionary.
            dic.Add("name", "Uttam");
            dic.Add("age", 19);
            dic.Add("isDeveloper", true);
            dic.Add("hobby", "Reading");
            dic.Add("college", "Darshan University");

            // Display objects of the Dictionary..
            foreach (var key in dic.Keys)
            {
                Console.WriteLine($"{key} : {dic[key]}");
            }

            // Remove specified object with help of key.
            dic.Remove("hobby");

            // Check whether the key is present or not in the Dictionary.
            dic.ContainsKey("age");

            // Check whether the value is present or not in the Dictionary.
            dic.ContainsValue("Uttam");

            // Count the number of objects are actually present in the Dictionary.
            int count = dic.Count;

            // Clear all the objects from the Dictionary.
            dic.Clear();
        }
    }
}
