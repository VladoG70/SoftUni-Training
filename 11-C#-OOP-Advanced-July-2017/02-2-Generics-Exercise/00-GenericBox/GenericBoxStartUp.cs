using System;

namespace _00_GenericBox
    {
    class GenericBoxStartUp
        {
        static void Main(string[] args)
            {
            Box<string> strBox = new Box<string>("test string");
            Box<int> intBox = new Box<int>(123123);

            Console.WriteLine(strBox);
            Console.WriteLine(intBox);
            }
        }
    }
