using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_GenericCountMethodDouble
    {
    class GenericCountMethodDoubleStartUp
        {
        static void Main(string[] args)
            {
            List<Box<double>> listOfBoxes = new List<Box<double>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
                {
                double doubleLine = double.Parse(Console.ReadLine());
                Box<double> doubleBox = new Box<double>(doubleLine);
                listOfBoxes.Add(doubleBox);
                }

            var benchmark = double.Parse(Console.ReadLine());
            var countGreaterElements = CountGreaterElements(listOfBoxes, benchmark);
            Console.WriteLine(countGreaterElements);
            }

        private static int CountGreaterElements<T>(List<Box<T>> listOfBoxes, T benchmark)
            where T : IComparable
            {
            int count = listOfBoxes.Count(b => b.Element.CompareTo(benchmark) > 0);

            return count;
            }
        }
    }
