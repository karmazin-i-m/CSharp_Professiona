using System;

namespace ITVDN_Task_2
{
    internal class Celsius : ITemperature, IEquatable<Celsius>
    {
        private double value;
        public double Value => value;

        public Celsius(double value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Celsius celsius && Equals(celsius);
        }

        public bool Equals(Celsius other)
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

        public static bool operator ==(Celsius left, Celsius right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Celsius left, Celsius right)
        {
            return !(left == right);
        }

        public static implicit operator Celsius(Kelvin kelvin)
        {
            return new Celsius(kelvin.Value + 273.15);
        }

        public static implicit operator Celsius(Fahrenheit fahrenheit)
        {
            double celsius = (fahrenheit.Value + 32) * (5 / 9);
            return new Celsius(celsius);
        }
    }
}
