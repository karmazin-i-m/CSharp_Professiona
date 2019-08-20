using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVDN_Task_3
{
    public abstract class Citizen :IEquatable<Citizen>
    {
        private int personalId;
        private string name;
        private int age;
        private string @class;

        protected Citizen(string name, int age, string @class)
        {
            this.name = name;
            this.age = age;
            this.@class = @class;
        }

        public int Age => age;

        public string Name => name;

        public int PersonalID => personalId;

        public string Class => @class;

        public override bool Equals(object obj)
        {
            return obj is Citizen citizen && Equals(citizen);
        }

        public bool Equals(Citizen citizen)
        {
            return personalId == citizen.personalId &&
                   name == citizen.name &&
                   age == citizen.age &&
                   Age == citizen.Age &&
                   Name == citizen.Name &&
                   PersonalID == citizen.PersonalID;
        }

        public override int GetHashCode()
        {
            return 197246712 + personalId.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Class: {this.Class}";
        }
    }
}