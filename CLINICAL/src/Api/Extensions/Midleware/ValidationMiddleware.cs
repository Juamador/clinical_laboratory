using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Application.UseCase.Commonds.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using ValidationException = CLINICAL.Application.UseCase.Commonds.Exceptions.ValidationException;

namespace Api.Extensions.Midleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next ;
        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = "Errores de validación",
                    Errors = ex.Errors
                });
            }
        }
    }
}
