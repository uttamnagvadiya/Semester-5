using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    internal class Indexers
    {
        private string[] strs = new string[3];
        public string this[int index]
        {
            get { return strs[index]; }
            set { strs[index] = value; }
        }

        public void display()
        {
            foreach (var item in strs)
            {
                Console.Write(item + " | ");
            }
        }
    }
}
