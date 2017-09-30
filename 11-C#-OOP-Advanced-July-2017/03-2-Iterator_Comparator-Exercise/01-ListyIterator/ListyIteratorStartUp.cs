using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ListyIterator
    {
    class ListyIteratorStartUp
        {
        static void Main(string[] args)
            {
            string command;
            var createCmd = Console.ReadLine().Split(' ').Skip(1);
            var listyIterator = new ListyIterator<string>(createCmd);

            while ((command = Console.ReadLine()) != "END")
                {

                switch (command)
                    {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                            {
                            listyIterator.Print();
                            }
                        catch (ArgumentException ae)
                            {
                            Console.WriteLine(ae.Message);
                            }
                        break;
                    default: break;
                    }
                }
            }
        }
    }
