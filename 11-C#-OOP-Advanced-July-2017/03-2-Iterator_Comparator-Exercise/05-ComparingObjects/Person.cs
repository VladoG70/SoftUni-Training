﻿using System;

namespace _05_ComparingObjects
    {
    public class Person : IComparable<Person>
        {
        private string name;
        private int age;
        private string town;

        public Person()
            { }

        public Person(string name, int age, string town)
            {
            this.name = name;
            this.age = age;
            this.town = town;
            }

        public int CompareTo(Person otherPerson)
            {
            var result = this.name.CompareTo(otherPerson.name);
            if (result == 0)
                {
                result = this.age.CompareTo(otherPerson.age);
                if (result == 0)
                    {
                    result = this.town.CompareTo(otherPerson.town);
                    }
                }

            return result;
            }
        }
    }
