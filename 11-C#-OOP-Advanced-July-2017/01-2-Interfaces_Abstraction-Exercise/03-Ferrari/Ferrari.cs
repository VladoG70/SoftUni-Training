using System.Text;

namespace _03_Ferrari
    {
    public class Ferrari : ICar
        {
        private string driver;
        private string model;

        public Ferrari(string driver, string model = "488-Spider")
            {
            this.Driver = driver;
            this.Model = model;
            }

        public string Driver
            {
            get { return this.driver; }
            private set { this.driver = value; }
            }

        public string Model
            {
            get { return this.model; }
            private set { this.model = value; }
            }

        public string Gas()
            {
            return "Zadu6avam sA!";
            }

        public string Brake()
            {
            return "Brakes!";
            }

        public override string ToString()
            {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}/{this.Brake()}/{this.Gas()}/{this.Driver}");

            return sb.ToString().Trim();
            }
        }
    }