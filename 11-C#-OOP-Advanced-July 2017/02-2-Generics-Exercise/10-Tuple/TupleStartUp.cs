using System;

namespace _10_Tuple
    {
    class TupleStartUp
        {
        static void Main(string[] args)
            {
            string[] inputLine1 = Console.ReadLine().Split(' ');
            string firstLastNames = $"{inputLine1[0]} {inputLine1[1]}";
            string address = inputLine1[2];
            Tuple<string, string> namesAndAddress = new Tuple<string, string>(firstLastNames, address);
            Console.WriteLine(namesAndAddress);

            string[] inputLine2 = Console.ReadLine().Split(' ');
            string name = inputLine2[0];
            int liters = int.Parse(inputLine2[1]);
            Tuple<string, int> namesAndLiters = new Tuple<string, int>(name, liters);
            Console.WriteLine(namesAndLiters);

            string[] inputLine3 = Console.ReadLine().Split(' ');
            int intValue = int.Parse(inputLine3[0]);
            double doubleValue = double.Parse(inputLine3[1]);
            Tuple<int, double> intDoublePair = new Tuple<int, double>(intValue, doubleValue);
            Console.WriteLine(intDoublePair);
            }
        }
    }
