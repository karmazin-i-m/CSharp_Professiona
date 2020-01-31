using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_2
{
    public static class Converter
    {
        public static double CelsiusToFaringate(double celsius)
        {
            return ((Fahrenheit) new Celsius(celsius)).Value;
        }
        public static double CelsiusToKelvin(double celsius)
        {
            return ((Kelvin)new Celsius(celsius)).Value;
        }
        public static double KelvinToFaringate(double kelvin)
        {
            return ((Fahrenheit)new Kelvin(kelvin)).Value;
        }
        public static double KelvinToCelsius(double kelvin)
        {
            return ((Celsius)new Kelvin(kelvin)).Value;
        }
        public static double FaringateToCelsius(double faringate)
        {
            return ((Celsius)new Fahrenheit(faringate)).Value;
        }
        public static double FaringateToKelvin(double faringate)
        {
            return ((Kelvin)new Fahrenheit(faringate)).Value;
        }
    }

}
