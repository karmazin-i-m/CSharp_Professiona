using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_2
{
    class Converter
    {
    }

    struct Celsius : ITemperature
    {
        private int value;

        public Celsius(int value)
        {
            this.value = value;
        }

        public int Value => throw new NotImplementedException();

        public bool Equals(ITemperature x, ITemperature y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(ITemperature obj)
        {
            throw new NotImplementedException();
        }
    }

    interface ITemperature : IEqualityComparer<ITemperature>
    {
        int Value { get; }
    }

}
