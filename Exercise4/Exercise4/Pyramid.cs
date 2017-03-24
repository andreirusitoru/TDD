using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Pyramid
    {
        public double Volume { get; set; }

        public Pyramid(double length, double width, double height)
        {
            Volume = (length * width * height) / 3;
        }
    }
}
