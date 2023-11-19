using Microsoft.AspNetCore.Mvc;

namespace HRLeavemanagement.API.Models
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();    
    }
}
