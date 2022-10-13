using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using SquareFinder.Figures;

namespace Tests
{
    [TestFixture]
    public class TestTriangle
    {
        private const double MachineEpsilon = 2.2e-15;

        [Test]
        public void TestValidation()
        {
            Assert.DoesNotThrow(() => CreateTriangle(3.0, 4.0, 5.0), "failed to create triangle with sides {0}, {1}, {2} ", 3.0, 4.0, 5.0);
            Assert.Throws<InvalidDataException>(() => CreateTriangle(3.0, 4.0, 7.0),
                "create triangle with sides {0}, {1}, {2} successfully, but triangle inequality is not met", 3.0, 4.0, 7.0);
            Assert.Throws<InvalidDataException>(() => CreateTriangle(3.0, 4.0, -7.0),
                "create triangle with sides {0}, {1}, {2} successfully, but some of them are negative", 3.0, 4.0, -7.0);
        }

        [Test]
        public void TestSquare()
        {
            Assert.Throws<TargetInvocationException>(() => SquareFinder.SquareFinder.FindSquare<Triangle>(1.0, 2.0),
                "method doesn't throw exception in spite of wrong arguments count - {0} instead of {1}", 2, 3);
            Assert.Throws<TargetInvocationException>(() => SquareFinder.SquareFinder.FindSquare<Triangle>(1.0, 2.0, 1.5, 2.0),
                "method doesn't throw exception in spite of wrong arguments count - {0} instead of {1}", 4, 3);
            ApproximatelyEqual(6.0, SquareFinder.SquareFinder.FindSquare<Triangle>(3.0, 4.0, 5.0));
        }

        [Test]
        public void TestRight()
        {
            Assert.True(new Triangle(3.0, 4.0, 5.0).Is_Right());
            Assert.False(new Triangle(3.0, 4.0, 6.0).Is_Right());
        }

        private static void ApproximatelyEqual(double expected, double actual)
        {
            Assert.Less(Math.Abs(expected - actual), MachineEpsilon);
        }

        private static void CreateTriangle(double a, double b, double c)
        {
            var unused = new Triangle(a, b, c);
        }
    }
}