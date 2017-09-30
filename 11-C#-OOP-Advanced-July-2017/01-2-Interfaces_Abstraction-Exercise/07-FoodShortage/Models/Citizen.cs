using _07_FoodShortage.Interfaces;

namespace _07_FoodShortage.Models
    {
    public class Citizen : IBuyer
        {
        private string name;
        private string age;
        private string id;
        private string birthdate;

        public Citizen(string name, string age, string id, string birthdate)
            {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
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

        public string Id
            {
            get { return this.id; }
            private set { this.id = value; }
            }

        public string Birthdate
            {
            get { return this.birthdate; }
            private set { this.birthdate = value; }
            }

        public int Food
            {
            get;
            private set;
            }

        public void BuyFood()
            {
            this.Food += 10;
            }
        }

    }
