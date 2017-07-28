using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_GenericBoxOfInteger
    {
    class GenericBoxOfIntegerStartUp
        {
        static void Main(string[] args)
            {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
                {
                int intLine = int.Parse(Console.ReadLine());
                Box<int> strBox = new Box<int>(intLine);
                Console.WriteLine(strBox);
                }
            }
        }
    }
