using _05_BorderControl.Interfaces;

namespace _05_BorderControl
    {
    internal class Robot : IIdentifiable, IName
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