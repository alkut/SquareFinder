using System;
using SquareFinder.Figures;

namespace SquareFinder
{
    public static class SquareFinder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <typeparam name="TFigure"></typeparam>
        /// <returns></returns>
        public static double FindSquare<TFigure>(params double[] args) where TFigure : IFigure, new()
        {
            TFigure figure = (TFigure)Activator.CreateInstance(typeof(TFigure), args);
            return figure.FindSquare();
        }
    }
}