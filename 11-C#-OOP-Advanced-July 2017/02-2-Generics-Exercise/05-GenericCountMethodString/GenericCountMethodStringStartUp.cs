using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_GenericCountMethodString
    {
    class GenericCountMethodStringStartUp
        {
        static void Main(string[] args)
            {
            List<Box<string>> listOfBoxes = new List<Box<string>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
                {
                string strLine = Console.ReadLine();
                Box<string> strBox = new Box<string>(strLine);
                listOfBoxes.Add(strBox);
                }

            var benchmark = Console.ReadLine();
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
