using Creacion_Del_Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddTransient<IMiddleware, MyCustomMiddleware>();   

var app = builder.Build();

// Veamos cómo funcionan los middlewares: continuos and chained.
// MIDDLEWARE CHAINS- using app.Use for the first middlewares and app.Run() for the last. 

// CUSTOM MIDDLEWARE 

// MIDDLEWARE 1 or REQUEST DELEGATE 1
app.UseMiddleware<MyCustomMiddleware>();

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