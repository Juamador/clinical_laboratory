namespace Api.Extensions.Midleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}
