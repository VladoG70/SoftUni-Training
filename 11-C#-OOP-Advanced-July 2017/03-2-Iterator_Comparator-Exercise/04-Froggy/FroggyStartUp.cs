using System;
using System.Linq;

namespace _04_Froggy
    {
    class FroggyStartUp
        {
        static void Main(string[] args)
            {
            var inputLine = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            Lake<int> stones = new Lake<int>(inputLine);

            Console.WriteLine(string.Join(", ", stones));
            }
        }
    }
