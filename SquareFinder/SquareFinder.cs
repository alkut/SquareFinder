using System;
using System.IO;
using System.Linq;
using System.Reflection;
using SquareFinder.Figures;

namespace SquareFinder
{
    /// <summary>
    /// example of usage: <br/>
    /// SquareFinder.SquareFinder.FindSquare&lt;Circle&gt;(1.0) <br/>
    /// To add custom figure see <see cref="IFigure"/>
    /// </summary>
    public static class SquareFinder
    {
        /// <summary>
        /// method to find a square of the figure <br/>
        /// example : double square = SquareFinder.SquareFinder.FindSquare&lt;Circle&gt;(1.0);
        /// </summary>
        /// <param name="args">
        /// Argument for constructor of TFigure <br/>
        /// see <see cref="Circle(double[])"/> for example or 
        /// <see cref="Triangle(double[])"/>
        /// </param>
        /// <exception cref="TargetInvocationException">
        /// throws when wrong count of args provided or args are incorrect
        /// </exception>
        public static double FindSquare<TFigure>(params double[] args) where TFigure : IFigure, new()
        {
            TFigure figure = (TFigure)Activator.CreateInstance(typeof(TFigure), args);
            return figure.FindSquare();
        }

        /// <summary>
        /// method to find a square of the figure <br/>
        /// example : double square = SquareFinder.SquareFinder.FindSquare(typeof(Circle), 1.0);
        /// </summary>
        /// <param name="type">Type, that implement IFigure</param>
        /// <param name="args">
        /// Argument for constructor of TFigure <br/>
        /// see <see cref="Circle(double[])"/> for example or 
        /// <see cref="Triangle(double[])"/>
        /// </param>
        /// <exception cref="InvalidDataException">
        /// throws when wrong type provided
        /// </exception>
        /// <exception cref="TargetInvocationException">
        /// throws when wrong count of args provided or args are incorrect
        /// </exception>
        public static double FindSquare(Type type, params double[] args)
        {
            if (!type.GetInterfaces().Contains(typeof(IFigure)))
                throw new InvalidDataException($"wrong type provided - {type} doesn't implement IFigure");
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(double[]) });
            object figure = ctor?.Invoke(new object[] {args});
            return (double)type
                .GetMethod("FindSquare", BindingFlags.Instance | BindingFlags.Public)
                .Invoke(figure, null);
        }
    }
}