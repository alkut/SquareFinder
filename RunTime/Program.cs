using System;
using System.Reflection;
using SquareFinder.Figures;


class MockTriangle : IFigure
{
    public MockTriangle()
    {
        
    }

    public MockTriangle(params double[] args)
    {
        
    }
    public double FindSquare()
    {
        return 0.0;
    }
}

namespace RunTime
{
    internal class Program
    {
        
        /// <summary>
        /// this show us that Square Finder can work without knowing type in compile time
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("input type (Triangle or MockTriangle)");
            string type = Console.ReadLine();
            
            Console.WriteLine("input 3 sides");
            int side1 = Int32.Parse(Console.ReadLine());
            int side2 = Int32.Parse(Console.ReadLine());
            int side3 = Int32.Parse(Console.ReadLine());

            if (type.Equals("Triangle"))
            {
                Console.WriteLine($"square is {SquareFinder.SquareFinder.FindSquare(typeof(Triangle), side1, side2, side3)}");
            }
            else if (type.Equals("MockTriangle"))
            {
                Console.WriteLine($"square is {SquareFinder.SquareFinder.FindSquare(typeof(MockTriangle), side1, side2, side3)}");
            }
        }
    }
}