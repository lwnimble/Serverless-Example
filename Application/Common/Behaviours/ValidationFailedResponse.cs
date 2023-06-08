using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Behaviours
{
    public static class ValidationFailedResponse
    {
        public static IActionResult ToBadRequestResponse(this ValidationException exception)
        {
            var result = new
            {
                message = "Validation Failed",
                errors = exception.Errors.Select(x => new { x.PropertyName, x.ErrorMessage, x.ErrorCode })
            };
            return new BadRequestObjectResult(result);
        }
    }
}
