using System;
using System.Collections.Generic;

namespace ITVDN_Task_2
{
    class Customer : IEquatable<Customer>
    {
        private readonly string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public string Name => name;

        public override bool Equals(object obj)
        {
            return Equals(obj as Customer);
        }

        public bool Equals(Customer other)
        {
            return other != null &&
                   name == other.name &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 629881564;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return EqualityComparer<Customer>.Default.Equals(left, right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !(left == right);
        }
    }
}
