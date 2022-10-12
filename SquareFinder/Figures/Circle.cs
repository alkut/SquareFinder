using System;
using System.IO;

namespace SquareFinder.Figures
{
    public class Circle : IFigure
    {
        private readonly double _radius;

        public Circle()
        {
            
        }

        public Circle(params double[] args)
        {
            if (args.Length != 1)
                throw new InvalidDataException($"wrong args count in triangle constructor : {args.Length} instead of 1");
            _radius = args[0];
            Validate();
        }

        public double FindSquare()
        {
            return Math.PI * _radius * _radius;
        }

        public void Validate()
        {
            if (_radius <= 0)
                throw new InvalidDataException($"can't create circle with following radius : {_radius} - non positive value");
        }
    }
}