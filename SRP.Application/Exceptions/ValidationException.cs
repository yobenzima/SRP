using FluentValidation.Results;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            foreach (var tError in validationResult.Errors)
            {
                Errors.Add(tError.ErrorMessage);
            }
        }
    }
}
