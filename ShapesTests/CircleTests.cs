using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Circle_NaN_ArgumentException()
        {
            new Circle(double.NaN);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Circle_PositiveInfinity_ArgumentException()
        {
            new Circle(double.PositiveInfinity);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Circle_NegativeInfinity_ArgumentException()
        {
            new Circle(double.NegativeInfinity);
        }

        [TestMethod]
        public void GetArea_Default()
        {
            double expected = 0;
            double actual = new Circle().GetArea();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetArea_Positive()
        {
            double expected = 400 * System.Math.PI;
            double actual = new Circle(20).GetArea();
            double delta = 1e-10;

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void GetArea_Negative()
        {
            double expected = 100 * System.Math.PI;
            double actual = new Circle(-10).GetArea();
            double delta = 1e-10;

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        [ExpectedException(typeof(System.OverflowException))]
        public void GetArea_MaxValue_OverflowException()
        {
            new Circle(double.MaxValue).GetArea();
        }

        [TestMethod]
        [ExpectedException(typeof(System.OverflowException))]
        public void GetArea_MinValue_OverflowException()
        {
            new Circle(double.MinValue).GetArea();
        }
    }
}
