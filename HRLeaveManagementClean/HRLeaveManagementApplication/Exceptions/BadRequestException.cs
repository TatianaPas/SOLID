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
            ValidationErrors = validationResult.ToDictionary();
        }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
