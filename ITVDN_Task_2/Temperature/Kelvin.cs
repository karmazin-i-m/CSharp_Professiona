using System;

namespace ITVDN_Task_2
{
    internal class Kelvin : ITemperature, IEquatable<Kelvin>
    {
        private double value;
        public double Value => value;

        public Kelvin(double value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Kelvin kelvin && Equals(kelvin);
        }

        public bool Equals(Kelvin other)
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

        public static bool operator ==(Kelvin left, Kelvin right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Kelvin left, Kelvin right)
        {
            return !(left == right);
        }

        public static implicit operator Kelvin(Celsius celsius)
        {
            return new Kelvin(celsius.Value + 273.15);
        }

        public static implicit operator Kelvin(Fahrenheit fahrenheit)
        {
            double kelvin = (fahrenheit.Value - 32) * (5 / 9) - 273.15;
            return new Kelvin(kelvin);
        }
    }

}
