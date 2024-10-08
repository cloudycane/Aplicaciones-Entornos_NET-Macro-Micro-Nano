using Creacion_Del_Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();

app.UseExceptionHandler("/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.UseAuthorization();
app.UseSession();
app.MapControllers();

//CUSTOM MIDDLEWARES 

app.Run();