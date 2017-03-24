using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CubeWaterVolume()
        {
            Cube cube = new Cube(2);
            Assert.AreEqual(8, cube.Volume);
        }

        [TestMethod]
        public void CylinderWaterVolume()
        {
            Cylinder cylinder = new Cylinder(2, 4);
            Assert.AreEqual(50.27f, cylinder.Volume, 0.01);
        }

        [TestMethod]
        public void PyramidWaterVolume()
        {
            Pyramid pyramid = new Pyramid(2,3,4);
            Assert.AreEqual(8, pyramid.Volume);
        }
    }
}
