using Presentation;
using static Shared.API.GlobalConstants;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container

//builder.ConfigureDatabase();

//builder.ConfigureIdentity();

builder.ConfigureControllers();

builder.ConfigureOpenAPI();

builder.ConfigureCors();

builder.ConfigureLoggingAndMemoryCache();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment()) app.ConfigureAPIDocs();

app.UseHttpsRedirection();

app.UseCors(ReactPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

