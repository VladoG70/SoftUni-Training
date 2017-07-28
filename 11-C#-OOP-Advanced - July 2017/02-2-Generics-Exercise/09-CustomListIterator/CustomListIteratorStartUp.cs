using System;

namespace _09_CustomListIterator
    {
    class CustomListIteratorStartUp
        {
        static void Main(string[] args)
            {
                CustomList<string> myCustomList = new CustomList<string>();
                string commandLine;

                while ((commandLine = Console.ReadLine()) != "END")
                {
                    var tokens = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var command = tokens[0];

                    switch (command)
                    {
                        case "Add":
                            myCustomList.Add(tokens[1]);
                            break;
                        case "Remove":
                            myCustomList.Remove(int.Parse(tokens[1]));
                            break;
                        case "Contains":
                            Console.WriteLine(myCustomList.Contains(tokens[1]));
                            break;
                        case "Swap":
                            myCustomList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                            break;
                        case "Greater":
                            Console.WriteLine(myCustomList.CountGreaterThan(tokens[1]));
                            break;
                        case "Min":
                            Console.WriteLine(myCustomList.Min());
                            break;
                        case "Max":
                            Console.WriteLine(myCustomList.Max());
                            break;
                        case "Sort":
                            myCustomList = Sorter.Sort(myCustomList);
                            break;
                        case "Print":
                            Console.WriteLine(myCustomList.Print());
                            //foreach (var element in myCustomList)
                            //{
                            //    Console.WriteLine(element);
                            //}
                            break;
                        default: break;
                    }
                }
            }
        }
    }
