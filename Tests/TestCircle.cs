using System;
using System.IO;
using NUnit.Framework;
using SquareFinder;
using SquareFinder.Figures;

namespace Tests
{
    [TestFixture]
    public class TestCircle
    {
        private const double MachineEpsilon = 2.2e-15;

        [Test]
        public void TestTriangleValidation()
        {
            Assert.DoesNotThrow(() => CreateCircle(3.0), "failed to create circle with radius {0}", 3.0);
            Assert.Throws<InvalidDataException>(() => CreateCircle(0.0),
                "create circle with radius {0} successfully, but radius is zero", 0.0);
            Assert.Throws<InvalidDataException>(() => CreateCircle(-3.0),
                "create circle with radius {0} successfully, but radius is negative", -3.0);
        }

        [Test]
        public void TestTriangleSquare()
        {
            ApproximatelyEqual(Math.PI, SquareFinder.SquareFinder.FindSquare<Circle>(1.0));
        }

        private static void ApproximatelyEqual(double expected, double actual)
        {
            Assert.Less(Math.Abs(expected - actual), MachineEpsilon);
        }

        private static void CreateCircle(double radius)
        {
            var unused = new Circle(radius);
        }
    }
}