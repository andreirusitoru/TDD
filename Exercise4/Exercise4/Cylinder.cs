using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Cylinder
    {
        public double Volume { get; set; }

        public Cylinder(double radius, double height)
        {
            Volume = Math.PI * Math.Pow(radius, 2) * height;
        }
    }
}
