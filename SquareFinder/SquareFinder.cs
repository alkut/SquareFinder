using System;
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
        /// method to find a square of the figure
        /// </summary>
        /// <param name="args">
        /// Argument for constructor of TFigure <br/>
        /// <seealso cref="Circle(params double[])"/>
        /// <seealso cref="Triangle(params double[])"/>
        /// </param>
        public static double FindSquare<TFigure>(params double[] args) where TFigure : IFigure, new()
        {
            TFigure figure = (TFigure)Activator.CreateInstance(typeof(TFigure), args);
            return figure.FindSquare();
        }
    }
}