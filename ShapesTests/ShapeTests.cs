using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
using System;

namespace ShapesTests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void StaticGetArea_Circle_Positive()
        {
            double expected = Math.PI * 400;
            double actual = Shape.GetArea(new Circle(20));
            double delta = 1e-10;

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void StaticGetArea_Triangle_Positive()
        {
            double expected = 6;
            double actual = Shape.GetArea(new Triangle(3, 4, 5));
            double delta = 1e-10;

            Assert.AreEqual(expected, actual, delta);
        }
    }
}
