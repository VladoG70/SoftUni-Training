using System;

namespace BashSoft.Attributes
    {
    [AttributeUsage(AttributeTargets.Class)]
    public class AlliasAttribute : Attribute
        {
        private string name;

        public AlliasAttribute(string aliasName)
            {
            this.name = aliasName;
            }

        public string Name
            {
            get { return this.name; }
            }

        public override bool Equals(object obj)
            {
            return this.Name.Equals(obj);
            }
        }
    }