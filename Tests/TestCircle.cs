using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using SquareFinder.Figures;

namespace Tests
{
    [TestFixture]
    public class TestCircle
    {
        private const double MachineEpsilon = 2.2e-15;

        [Test]
        public void TestValidation()
        {
            Assert.DoesNotThrow(() => CreateCircle(3.0), "failed to create circle with radius {0}", 3.0);
            Assert.Throws<InvalidDataException>(() => CreateCircle(0.0),
                "create circle with radius {0} successfully, but radius is zero", 0.0);
            Assert.Throws<InvalidDataException>(() => CreateCircle(-3.0),
                "create circle with radius {0} successfully, but radius is negative", -3.0);
        }

        [Test]
        public void TestSquare()
        {
            Assert.Throws<TargetInvocationException>(() => SquareFinder.SquareFinder.FindSquare<Circle>(),
                "method doesn't throw exception in spite of wrong arguments count - {0} instead of {1}", 0, 1);
            Assert.Throws<TargetInvocationException>(() => SquareFinder.SquareFinder.FindSquare<Circle>(1.0, 2.0),
                "method doesn't throw exception in spite of wrong arguments count - {0} instead of {1}", 2, 1);
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