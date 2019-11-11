﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Common.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public abstract string Code { get; }

        protected ExceptionBase(string message) : base(message)
        {
        }
    }
}
