using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Stack
    {
    class StackStartUp
        {
        static void Main(string[] args)
            {
            Stack<int> ourStack = new Stack<int>();
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
                {
                var commandLine = inputLine
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string command = commandLine[0];

                switch (command)
                    {
                    case "Push":
                        var pushParams = commandLine
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();
                        ourStack.Push(pushParams);
                        break;

                    case "Pop":
                        try
                            {
                            ourStack.Pop();
                            }
                        catch (ArgumentException ae)
                            {
                            Console.WriteLine(ae.Message);
                            }
                        break;

                    default: break;
                    }
                }

            if (ourStack.Count() != 0)
                {
                foreach (var element in ourStack)
                    {
                    Console.WriteLine(element);
                    }
                }

            }
        }
    }
