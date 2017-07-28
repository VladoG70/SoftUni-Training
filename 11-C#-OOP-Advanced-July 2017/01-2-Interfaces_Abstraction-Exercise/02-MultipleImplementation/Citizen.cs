namespace _02_MultipleImplementation
    {
    public class Citizen : IIdentifiable, IBirthable
        {
        private int age;
        private string birthdate;
        private string id;
        private string name;

        public Citizen(string name, int age, string id, string birthdate)
            {
            this.name = name;
            this.age = age;
            this.id = id;
            this.birthdate = birthdate;
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
        }
    }