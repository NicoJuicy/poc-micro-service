using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Core.Exceptions
{
    public class InvalidAggregateIdException : ExceptionBase
    {
        public override string Code => "invalid_aggregate_id";

        public InvalidAggregateIdException() : base($"Invalid aggregate id.")
        {
        }
    }
}
