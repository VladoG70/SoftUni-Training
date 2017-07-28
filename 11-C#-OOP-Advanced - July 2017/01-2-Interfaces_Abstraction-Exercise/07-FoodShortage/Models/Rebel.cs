using _07_FoodShortage.Interfaces;

namespace _07_FoodShortage.Models
    {
    public class Rebel : IBuyer
        {
        private string name;
        private string age;
        private string group;


        public Rebel(string name, string age, string group)
            {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            }

        public string Name
            {
            get { return this.name; }
            private set { this.name = value; }
            }

        public string Age
            {
            get { return this.age; }
            private set { this.age = value; }
            }

        public string Group
            {
            get { return this.group; }
            private set { this.group = value; }
            }

        public int Food { get; private set; }

        public void BuyFood()
            {
            this.Food += 5;
            }
        }
    }
