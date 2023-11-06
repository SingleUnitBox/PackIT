using PackIt.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIt.Domain.ValueObject
{
    public record Temperature
    {
        public double Value { get; }
        public Temperature(double value)
        {
            if (value < -100 || value > 100)
            {
                throw new InvalidTemperatureException(value);
            }

            Value = value;
        }

        public static implicit operator double(Temperature temperature) => temperature.Value;
        public static implicit operator Temperature(double value) => new Temperature(value);
    }
}
