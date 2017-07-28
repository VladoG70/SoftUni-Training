using _05_BorderControl.Interfaces;

namespace _05_BorderControl
    {
    public class Citizen : IIdentifiable, IName, IAge
        {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
            {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            }

        public string Id
            {
            get { return this.id; }
            private set { this.id = value; }
            }

        public string Name
            {
            get { return this.name; }
            private set { this.name = value; }
            }

        public int Age
            {
            get { return this.age; }
            private set { this.age = value; }
            }
        }
    }