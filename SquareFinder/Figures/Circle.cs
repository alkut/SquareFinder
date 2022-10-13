using System;
using System.IO;

namespace SquareFinder.Figures
{
    /// <summary>
    /// Class represent Circle Figure by radius as parameter
    /// </summary>
    public class Circle : IFigure
    {
        private readonly double _radius;

        public Circle()
        {
            
        }

        /// <summary>
        /// Create circle with specified radius
        /// </summary>
        /// <param name="args">
        /// Note that constructor takes exactly 1 arg - positive double
        /// </param>
        /// <exception cref="InvalidDataException"></exception>
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

        /// <summary>
        /// check the correctness of constructor args
        /// </summary>
        /// <exception cref="InvalidDataException"></exception>
        private void Validate()
        {
            if (_radius <= 0)
                throw new InvalidDataException($"can't create circle with following radius : {_radius} - non positive value");
        }
    }
}