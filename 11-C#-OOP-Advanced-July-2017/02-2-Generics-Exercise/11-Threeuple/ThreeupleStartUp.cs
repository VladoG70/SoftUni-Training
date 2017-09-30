using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Threeuple
    {
    class ThreeupleStartUp
        {
        static void Main(string[] args)
            {
            string[] inputLine1 = Console.ReadLine().Split(' ');
            string firstLastNames = $"{inputLine1[0]} {inputLine1[1]}";
            string address = inputLine1[2];
            string town = inputLine1[3];
            Threeuple<string, string, string> namesAddressAndTown = new Threeuple<string, string, string>(firstLastNames, address, town);
            Console.WriteLine(namesAddressAndTown);

            string[] inputLine2 = Console.ReadLine().Split(' ');
            string drunkerName = inputLine2[0];
            int liters = int.Parse(inputLine2[1]);
            bool drunkOrNot = inputLine2[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> namesLitersAndDrunk = new Threeuple<string, int, bool>(drunkerName, liters, drunkOrNot);
            Console.WriteLine(namesLitersAndDrunk);

            string[] inputLine3 = Console.ReadLine().Split(' ');
            string name = inputLine3[0];
            double bankBalance = double.Parse(inputLine3[1]);
            string bankName = inputLine3[2];
            Threeuple<string, double, string> nameAccountBank = new Threeuple<string, double, string>(name, bankBalance, bankName);
            Console.WriteLine(nameAccountBank);
            }
        }
    }
