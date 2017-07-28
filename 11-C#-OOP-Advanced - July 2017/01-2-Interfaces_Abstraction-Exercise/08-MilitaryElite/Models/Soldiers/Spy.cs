using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MilitaryElite.Models.Soldiers
    {
    public class Spy : Soldier, ISpy
        {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
            {
            this.CodeNumber = codeNumber;
            }

        public int CodeNumber { get; private set; }

        public override string ToString()
            {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
                .AppendLine($"Code Number: {this.CodeNumber}");

            return sb.ToString().Trim();
            }
        }
    }
