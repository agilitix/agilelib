using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AxUtils
{
    /*
       Validate properties :

            public class MyClass
            {
                [Required]
                [StringLength(10, MinimumLength = 3)]
                public string Name { get; set; }
            }

            class Program
            {
                MyClass obj = new MyClass();
                obj.Name = "Jo";

                List<ValidationResult> results;
                bool isValid = obj.IsValid(out results); // "The field Name must be a string with a minimum length of 3 and a maximum length of 10."
            }
     */

    public class InvalidModelException : Exception
    {
        public ValidationResult[] ValidationResults { get; }

        public InvalidModelException(IEnumerable<ValidationResult> results)
        {
            ValidationResults = results.ToArray();
        }
    }

    public static class ModelValidatorExtensions
    {
        public static void Validate(this object self)
        {
            List<ValidationResult> results;
            bool isValid = IsValid(self, out results);
            if (!isValid)
            {
                throw new InvalidModelException(results);
            }
        }

        public static bool IsValid(this object self)
        {
            var validationContext = new ValidationContext(self, null, null);
            return Validator.TryValidateObject(self, validationContext, null, true);
        }

        public static bool IsValid(this object self, out List<ValidationResult> results)
        {
            var validationContext = new ValidationContext(self, null, null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(self, validationContext, results, true);
        }
    }

    public class ValidateObjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);
            if (!Validator.TryValidateObject(value, context, results, true))
            {
                var compositeResults = new CompositeValidationResult(string.Format("Validation for {0} failed!", validationContext.DisplayName));
                results.ForEach(compositeResults.AddResult);

                return compositeResults;
            }

            return ValidationResult.Success;
        }
    }

    public class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();

        public IEnumerable<ValidationResult> Results => _results;

        public CompositeValidationResult(string errorMessage)
            : base(errorMessage)
        {
        }

        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames)
            : base(errorMessage, memberNames)
        {
        }

        protected CompositeValidationResult(ValidationResult validationResult)
            : base(validationResult)
        {
        }

        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
}
