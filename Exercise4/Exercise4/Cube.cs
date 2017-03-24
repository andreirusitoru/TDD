using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Cube
    {
        public double Volume { get; set; }

        public Cube(double width)
        {
            Volume = Math.Pow(width, 3);
        }
    }
}
