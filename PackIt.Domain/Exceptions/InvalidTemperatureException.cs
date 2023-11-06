using PackIt.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIt.Domain.Exceptions
{
    public class InvalidTemperatureException : PackItException
    {
        public double Value { get; }
        public InvalidTemperatureException(double value) : base($"Value {value} is invalid temperature")
        {
            Value = value;
        }
    }
}
