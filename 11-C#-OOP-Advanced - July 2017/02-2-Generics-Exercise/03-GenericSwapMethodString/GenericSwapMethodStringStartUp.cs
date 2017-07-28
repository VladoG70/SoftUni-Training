using System;
using System.Collections.Generic;

namespace _03_GenericSwapMethodString
    {
    class GenericSwapMethodStringStartUp
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

            var swapCmd = Console.ReadLine().Split(' ');
            int index1 = int.Parse(swapCmd[0]);
            int index2 = int.Parse(swapCmd[1]);

            SwapStrings(listOfBoxes, index1, index2);

            foreach (Box<string> box in listOfBoxes)
                {
                Console.WriteLine(box);
                }
            }

        private static void SwapStrings<T>(List<Box<T>> listOfBoxes, int index1, int index2)
            {
            Box<T> tempBox = listOfBoxes[index1];
            listOfBoxes[index1] = listOfBoxes[index2];
            listOfBoxes[index2] = tempBox;
            }
        }
    }
