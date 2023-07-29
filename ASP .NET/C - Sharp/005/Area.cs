using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    internal class Area
    {
        public float area(float length)
        {
            return (length * length);
        }

        public float area(float width, float height)
        {
            return (width * height);
        }

        public float area(int radius)
        {
            return (3.14f * radius * radius);
        }
    }
}
