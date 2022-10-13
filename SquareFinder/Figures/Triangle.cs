using System;
using System.IO;

namespace SquareFinder.Figures
{
    /// <summary>
    /// Class represent Triangle Figure by sides as parameters
    /// </summary>
    public class Triangle : IFigure
    {
        /// <summary>
        /// _a, _b, _c is sorted in ascending order
        /// </summary>
        private readonly double _a, _b, _c;
        /// <summary>
        /// machine eps - maximum positive double such 1 + eps == 1
        /// </summary>
        private const double MachineEpsilon = 2.2e-15;

        public Triangle()
        {
            
        }

        /// <summary>
        /// Create triangle with specified sides
        /// </summary>
        /// <param name="args">
        /// Note that constructor takes exactly 3 args - positive double <br/>
        /// Also there is no triangle with side more or equal than sum of other(triangle inequality)
        /// </param>
        /// <exception cref="InvalidDataException"></exception>
        public Triangle(params double[] args)
        {
            if (args.Length != 3)
                throw new InvalidDataException($"wrong args count in triangle constructor : {args.Length} instead of 3");
            Array.Sort(args);
            _a = args[0];
            _b = args[1];
            _c = args[2];
            Validate();
        }
        
        /// <summary>
        /// using Heron's formula S = sqrt(p * (p - a) * (p - b) * (p - c)) where p = (a + b + c) / 2 <br/>
        /// triangle inequality is equivalent to p > a and p > b and p > c thus every factor is positive - see <see cref="Triangle.Validate()"/>
        /// </summary>
        public double FindSquare()
        {
            double semiperimeter = (_a + _b + _c) / 2.0;
            return Math.Sqrt(semiperimeter * (semiperimeter - _a) * (semiperimeter - _b) * (semiperimeter - _c));
        }

        /// <summary>
        /// triangle is right iff a^2 + b^2 = c^2 where c is the greatest side - according to the law of cosines
        /// </summary>
        /// <returns></returns>
        public bool Is_Right()
        {
            return Math.Abs(_a * _a + _b * _b - _c * _c) < MachineEpsilon;
        }

        /// <summary>
        /// check the correctness of constructor args
        /// </summary>
        /// <exception cref="InvalidDataException"></exception>
        private void Validate()
        {
            if (_a < 0)
                throw new InvalidDataException($"can't create triangle with following sides : {_a}, {_b}, {_c} - some of them are negative");
            if (_c >= _a + _b)
                throw new InvalidDataException($"can't create triangle with following sides : {_a}, {_b}, {_c} - triangle inequality is not met");
        }
    }
}