
using System;

class GenericScaleStartUp
    {
    static void Main(string[] args)
        {
            var genericScale = new Scale<int>(2, 3);
            Console.WriteLine(genericScale.GetHavier());
        }
    }