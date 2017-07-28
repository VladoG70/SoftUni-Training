using _06_BirthdayCelebrations.Interfaces;

namespace _06_BirthdayCelebrations
    {
    public class Robot : IIdentifiable, IName
        {
        private string name;
        private string id;

        public Robot(string name, string id)
            {
            this.Name = name;
            this.Id = id;
            }

        public string Name
            {
            get { return this.name; }
            private set { this.name = value; }
            }

        public string Id
            {
            get { return this.id; }
            private set { this.id = value; }
            }
        }
    }