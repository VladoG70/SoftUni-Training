using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_GenericSwapMethodInteger
    {
    class GenericSwapMethodIntegerStartUp
        {
        static void Main(string[] args)
            {
            List<Box<int>> listOfBoxes = new List<Box<int>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
                {
                int intLine = int.Parse(Console.ReadLine());
                Box<int> intBox = new Box<int>(intLine);
                listOfBoxes.Add(intBox);
                }

            var swapIndxs = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int index1 = swapIndxs[0];
            int index2 = swapIndxs[1];

            SwapInts(listOfBoxes, index1, index2);

            foreach (Box<int> box in listOfBoxes)
                {
                Console.WriteLine(box);
                }
            }

        private static void SwapInts<T>(List<Box<T>> listOfBoxes, int index1, int index2)
            {
            Box<T> tempBox = listOfBoxes[index1];
            listOfBoxes[index1] = listOfBoxes[index2];
            listOfBoxes[index2] = tempBox;
            }
        }
    }
