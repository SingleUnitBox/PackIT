using PackIt.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIt.Domain.Policies
{
    public record PolicyData(TravelDays Days, Consts.Gender Gender, Temperature Temperature, Localization Localization)
    {
    }
}
