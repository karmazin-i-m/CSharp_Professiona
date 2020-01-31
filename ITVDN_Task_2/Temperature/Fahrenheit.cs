using System;

namespace ITVDN_Task_2
{
    internal class Fahrenheit : ITemperature, IEquatable<Fahrenheit>
    {
        private double value;
        public double Value => value;

        public Fahrenheit(double value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Fahrenheit fahrenheit && Equals(fahrenheit);
        }

        public bool Equals(Fahrenheit other)
        {
            return value == other.value &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            var hashCode = 1927018180;
            hashCode = hashCode * -1521134295 + value.GetHashCode();
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Fahrenheit left, Fahrenheit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Fahrenheit left, Fahrenheit right)
        {
            return !(left == right);
        }

        public static implicit operator Fahrenheit(Kelvin kelvin)
        {
            double fahrenheit = (kelvin.Value - 273.15) * (9 / 5) + 32;
            return new Fahrenheit(fahrenheit);
        }

        public static implicit operator Fahrenheit(Celsius celsius)
        {
            double fahrenheit = celsius.Value * 9 / 5 + 32;
            return new Fahrenheit(fahrenheit);
        }
    }

}
