
namespace Creacion_Del_Middlewares
{
    public class MyCustomMiddleware : IMiddleware // Middleware Interface and Class
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is my custom middleware.");
            await next(context);
            await context.Response.WriteAsync("Another custom middleware.");
        }
    }
}
