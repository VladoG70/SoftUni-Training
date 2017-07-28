using _06_BirthdayCelebrations.Interfaces;

namespace _06_BirthdayCelebrations
    {
    public class Pet : IName, IBirthdate
        {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
            {
            this.Name = name;
            this.Birthdate = birthdate;
            }

        public string Name
            {
            get { return this.name; }
            private set { this.name = value; }
            }

        public string Birthdate
            {
            get { return this.birthdate; }
            private set { this.birthdate = value; }
            }
        }
    }