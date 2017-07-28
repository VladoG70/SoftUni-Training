using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ExplicitInterfaces
    {
    class ExplicitInterfacesStartUp
        {
        static void Main(string[] args)
            {
            string input;
            while ((input = Console.ReadLine()) != "End")
                {
                var personInfo = input.Split();
                var person = new Citizen(personInfo[0]);
                Console.WriteLine(((IPerson)person).GetName());
                Console.WriteLine(((IResident)person).GetName());
                }
            }
        }
    }
