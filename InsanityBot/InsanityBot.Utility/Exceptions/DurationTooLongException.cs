﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanityBot.Utility.Exceptions
{
    public class DurationTooLongException : Exception
    {
        public DurationTooLongException(String message) : base(message)
        {
        }
    }
}
