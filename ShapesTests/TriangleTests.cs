using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Triangle_NaN_ArgumentException()
        {
            new Triangle(double.NaN, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Triangle_PositiveInfinity_ArgumentException()
        {
            new Triangle(0, double.PositiveInfinity, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Triangle_NegativeInfinity_ArgumentException()
        {
            new Triangle(2, -1, double.NegativeInfinity);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Triangle_Impossible_ArgumentException()
        {
            new Triangle(10, 11, 22);
        }

        [TestMethod]
        public void GetArea_Default()
        {
            double expected = 0;
            double actual = new Triangle().GetArea();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetArea_Zero()
        {
            double expected = 0;
            double actual = new Triangle(10, 10, 20).GetArea();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetArea_Positive()
        {
            double expected = 6;
            double actual = new Triangle(3, 5, 4).GetArea();
            double delta = 1e-10;

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void GetArea_Negative()
        {
            double expected = 6;
            double actual = new Triangle(-3, -5, -4).GetArea();
            double delta = 1e-10;

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        [ExpectedException(typeof(System.OverflowException))]
        public void GetArea_MaxValue_OverflowException()
        {
            new Triangle(10, double.MaxValue, double.MaxValue).GetArea();
        }

        [TestMethod]
        [ExpectedException(typeof(System.OverflowException))]
        public void GetArea_MinValue_OverflowException()
        {
            new Triangle(10, double.MinValue, double.MinValue).GetArea();
        }

        [TestMethod]
        public void IsRight_Right()
        {
            bool expected = true;
            bool actual = new Triangle(10, 6, 8).IsRight();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRight_Obtuse()
        {
            bool expected = false;
            bool actual = new Triangle(20, 18, 5).IsRight();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRight_Actue()
        {
            bool expected = false;
            bool actual = new Triangle(8, 7, 9).IsRight();

            Assert.AreEqual(expected, actual);
        }
    }
}
