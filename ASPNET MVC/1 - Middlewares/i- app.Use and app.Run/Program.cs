var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Veamos cómo funcionan los middlewares: continuos and chained.
// MIDDLEWARE CHAINS- using app.Use for the first middlewares and app.Run() for the last. 

// MIDDLEWARE 1 or REQUEST DELEGATE 1
app.Use(async (HttpContext context, RequestDelegate next) => // hemos utilizado una lambda expression y async-await method
{
    await context.Response.WriteAsync("Hola!");
    await next(context); // For calling the next middleware
});

// MIDDLEWARE 2 or REQUEST DELEGATE 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    var a = "Bienvenidos a mi pagina";
    var b = "\nMi nombre es Jay";
    var enunciado = a + b;
    await context.Response.WriteAsync($"{enunciado}");
}); 

// MIDDLEWARE 3 or REQUEST DELEGATE 3
app.Run();

/*
 
 THE PURPOSE OF MIDDLEWARES:  Handle every single methods (only occurs in Program.cs or a customized and heavily typed class)
 
 */

/// <summary>
/// For example, we create a middleware to handle http redirection, import services, authorization, handling controllers and razor pages and so much more
/// </summary>