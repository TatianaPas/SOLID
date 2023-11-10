using System.ComponentModel.DataAnnotations;

namespace HRLeaveManagementApplication.Exceptions
{
    public class BadRequestException : Exception
    {
        private FluentValidation.Results.ValidationResult validationResult;

        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, FluentValidation.Results.ValidationResult validationResult) : this(message)
        {
            ValidationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

        public List<string> ValidationErrors { get; set; }
    }
}
