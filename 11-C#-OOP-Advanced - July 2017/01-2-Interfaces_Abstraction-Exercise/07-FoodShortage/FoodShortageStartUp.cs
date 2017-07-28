using System;
using System.Collections.Generic;
using System.Linq;
using _07_FoodShortage.Interfaces;
using _07_FoodShortage.Models;

namespace _07_FoodShortage
    {
    class FoodShortageStartUp
        {
        static void Main(string[] args)
            {
                var peopleCount = int.Parse(Console.ReadLine());

                var foodStats = new List<IBuyer>();

                for (int i = 0; i < peopleCount; i++)
                {
                    var input = Console.ReadLine().Split(' ');

                    if (input.Length == 3)
                    {
                        var rebel = new Rebel(input[0], input[1], input[2]);
                        foodStats.Add(rebel);
                    }

                    else
                    {
                        var citizen = new Citizen(input[0], input[1], input[2], input[3]);
                        foodStats.Add(citizen);
                    }
                }

                string name;
                while ((name = Console.ReadLine()) != "End")
                {
                    var buyer = foodStats.Where(b => b.Name == name).FirstOrDefault();

                    if (buyer != null)
                    {
                        buyer.BuyFood();
                    }
                }

                Console.WriteLine(foodStats.Sum(b => b.Food));
            }
        }
    }
