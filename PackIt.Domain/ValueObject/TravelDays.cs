using PackIt.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIt.Domain.ValueObject
{
    public record TravelDays
    {
        public ushort Days { get; }
        public TravelDays(ushort days)
        {
            if (days == 0 || days > 100)
            {
                throw new InvalidTravelDaysException(days);
            }

            Days = days;
        }

        public static implicit operator ushort(TravelDays travelDays) => travelDays.Days;
        public static implicit operator TravelDays(ushort days) => new TravelDays(days);
    }
}
