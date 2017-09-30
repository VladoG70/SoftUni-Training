using System;

namespace _01_GenericBoxOfString
    {
    class GenericBoxOfStringStartUp
        {
        static void Main(string[] args)
            {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
                {
                string strLine = Console.ReadLine();
                Box<string> strBox = new Box<string>(strLine);
                Console.WriteLine(strBox);
                }
            }
        }
    }
