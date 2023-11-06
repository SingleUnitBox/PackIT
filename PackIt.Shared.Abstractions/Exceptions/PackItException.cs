﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIt.Shared.Abstractions.Exceptions
{
    public class PackItException : Exception
    {
        protected PackItException(string message) : base(message)
        { }
    }
}
