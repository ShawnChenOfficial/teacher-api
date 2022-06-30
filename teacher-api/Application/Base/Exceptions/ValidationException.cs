using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace teacher_api.Application.Base.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                 .Select(e => string.IsNullOrWhiteSpace(e.PropertyName) ? $"{e.ErrorMessage}" : $"{e.PropertyName}: {e.ErrorMessage}")
                 .ToList();
        }

        public ValidationException(IEnumerable<IdentityError> failures)
             : this()
        {
            Errors = failures
                .Select(e => $"{e.Code}: {e.Description}")
                .ToList();
        }


        public List<string> Errors { get; }
    }
}