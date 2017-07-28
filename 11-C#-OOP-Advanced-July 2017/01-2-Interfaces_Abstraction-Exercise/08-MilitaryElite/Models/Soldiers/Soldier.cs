using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MilitaryElite.Models.Soldiers
    {
    public abstract class Soldier : ISoldier
        {
        protected Soldier(string id, string firstName, string lastName)
            {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            }

        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        }
    }
