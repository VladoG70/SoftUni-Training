using System;
using System.Collections.Generic;

namespace _05_ComparingObjects
    {
    class ComparingObjectsStartUp
        {
        static void Main(string[] args)
            {
            List<Person> people = new List<Person>();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
                {
                var peopleInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = peopleInfo[0];
                var age = int.Parse(peopleInfo[1]);
                var town = peopleInfo[2];

                Person person = new Person(name, age, town);

                people.Add(person);
                }

            var personN = int.Parse(Console.ReadLine()) - 1;
            var totalnumberOfPeople = people.Count;
            var numberOfEqualPeople = 0;

            for (int i = 0; i < totalnumberOfPeople; i++)
                {
                if (people[i].CompareTo(people[personN]) == 0)
                    {
                    numberOfEqualPeople++;
                    }
                }

            if (numberOfEqualPeople == 1)
                {
                Console.WriteLine("No matches");
                }
            else
                {
                Console.WriteLine($"{numberOfEqualPeople} {totalnumberOfPeople - numberOfEqualPeople} {totalnumberOfPeople}");
                }

            }
        }
    }
