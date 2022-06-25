using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace OrderingApplication.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("One or More validation failures have accurred.")
        {
            Erros = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Erros = failures
                  .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                  .ToDictionary(failureGrouped => failureGrouped.Key, failureGrouped => failureGrouped.ToArray());
        }

        public Dictionary<string, string[]> Erros { get; }

    }
}
