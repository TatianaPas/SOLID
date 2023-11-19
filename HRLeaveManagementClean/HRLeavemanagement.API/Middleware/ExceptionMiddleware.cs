using HRLeavemanagement.API.Models;
using HRLeaveManagementApplication.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using SendGrid.Helpers.Errors.Model;
using System.Net;
using BadRequestException = HRLeaveManagementApplication.Exceptions.BadRequestException;
using NotFoundException = HRLeaveManagementApplication.Exceptions.NotFoundException;

namespace HRLeavemanagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
              await HandleExceptionAsync(context,ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpCcontext, Exception ex)
        {
            HttpStatusCode stautsCode = HttpStatusCode.InternalServerError;
            ValidationProblemDetails problem = new();

            switch(ex)
            {
                case BadRequestException badRequestException:
                    stautsCode = HttpStatusCode.BadRequest;
                    problem = new ValidationProblemDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)stautsCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        Errors = badRequestException.ValidationErrors
                    };
                    break;
                case NotFoundException NotFound:
                    stautsCode = HttpStatusCode.NotFound;
                    problem = new ValidationProblemDetails
                    {
                        Title = NotFound.Message,
                        Status = (int)stautsCode,
                        Detail = NotFound.InnerException?.Message,
                        Type = nameof(HRLeaveManagementApplication.Exceptions.NotFoundException),
                    };
                    break;
                default:
                    problem = new ValidationProblemDetails
                    {
                        Title = ex.Message,
                        Status = (int)stautsCode,
                        Detail = ex.StackTrace,
                        Type = nameof(HttpStatusCode.InternalServerError),
                    };
                    break;
            }
            httpCcontext.Response.StatusCode = (int)stautsCode;
            await httpCcontext.Response.WriteAsJsonAsync(problem);
        }
    }
}
