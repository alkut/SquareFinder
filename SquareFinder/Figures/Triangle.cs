using System;
using System.IO;

namespace SquareFinder.Figures
{
    public class Triangle : IFigure
    {
        private readonly double _a, _b, _c;
        private const double MachineEpsilon = 2.2e-15;

        public Triangle()
        {
            
        }

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

        public double FindSquare()
        {
            double semiperimeter = (_a + _b + _c) / 2.0;
            return Math.Sqrt(semiperimeter * (semiperimeter - _a) * (semiperimeter - _b) * (semiperimeter - _c));
        }

        public bool Is_Right()
        {
            return Math.Abs(_a * _a + _b * _b - _c * _c) < MachineEpsilon;
        }

        public void Validate()
        {
            if (_a < 0)
                throw new InvalidDataException($"can't create triangle with following sides : {_a}, {_b}, {_c} - some of them are negative");
            if (_c >= _a + _b)
                throw new InvalidDataException($"can't create triangle with following sides : {_a}, {_b}, {_c} - triangle inequality is not met");
        }
    }
}