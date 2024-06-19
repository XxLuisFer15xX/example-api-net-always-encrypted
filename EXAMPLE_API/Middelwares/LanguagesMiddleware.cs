using EXAMPLE_API.Entities.Config;

namespace EXAMPLE_API.Middlewares
{
    public class LanguagesMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguagesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var languages = context.Request.Headers["Accept-Language"].FirstOrDefault();
                if (languages == "es")
                {
                    context.Items["languages"] = Languages.es;
                }
                else
                {
                    context.Items["languages"] = Languages.en;
                }
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Ocurrió un error inesperado: " + ex.Message);
            }
        }

    }
}
