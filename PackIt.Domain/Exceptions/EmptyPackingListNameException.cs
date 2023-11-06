﻿using PackIt.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIt.Domain.Exceptions
{
    public class EmptyPackingListNameException : PackItException
    {
        public EmptyPackingListNameException() : base("Packing list name cannot be empty.")
        {
        }
    }
}
