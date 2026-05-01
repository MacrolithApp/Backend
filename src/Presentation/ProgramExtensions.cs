using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using static Shared.API.GlobalConstants;

namespace Presentation;

public static class ProgramExtensions
{
    public static void ConfigureLoggingAndMemoryCache(this WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment()) builder.Logging.SetMinimumLevel(LogLevel.Debug);
        else builder.Logging.SetMinimumLevel(LogLevel.Warning);

        builder.Services.AddMemoryCache();
    }

    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        //     builder.Services.AddDbContext<MacrolithDbContext>(options =>
        //         options.UseNpgsql(builder.Configuration.GetConnectionString(DbConnectionString)));
    }

    public static void ConfigureIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole<Guid>>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;

            options.User.RequireUniqueEmail = true;

            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        });
        // .AddEntityFrameworkStores<MacrolithDbContext>()
        // .AddDefaultTokenProviders();
    }

    public static void ConfigureControllers(this WebApplicationBuilder builder)
    {
        builder.Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(opt =>
        {
            // Suppress Multipart/form-data inference
            opt.SuppressConsumesConstraintForFormFileParameters = true;
            // Suppress automatic binding source attributes
            opt.SuppressInferBindingSourcesForParameters = true;
            // Suppress automatic HTTP 400 errors
            opt.SuppressModelStateInvalidFilter = true;
        });
    }

    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        // Register cross-origin requests for communication with React
        string? reactUrl = builder.Configuration["Cors:AllowedOrigin"];

        if (string.IsNullOrEmpty(reactUrl))
        {
            throw new InvalidOperationException("CORS origin is not configured.");
        }

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(ReactPolicy, policy =>
            {
                policy.WithOrigins(reactUrl)
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
        });
    }

    public static void ConfigureOpenAPI(this WebApplicationBuilder builder)
    {
        // Configuring Microsoft’s newer built-in OpenAPI support
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, ct) =>
            {
                document.Info.Title = APITitle;
                document.Info.Version = APIVersion;
                document.Info.Description = APIDescription;
                return Task.CompletedTask;
            });
        });
    }

    public static void ConfigureAPIDocs(this WebApplication app)
    {
        // Configure path for OpenAPI document
        app.MapOpenApi(OpenAPIDocumentRoute);

        // Configure Scalar API
        app.MapScalarApiReference(DefaultEndpoint, options =>
        {
            options.WithTitle(APITitle)
              .ForceDarkMode()
              .HideSearch()
              .ShowOperationId()
              .ExpandAllTags()
              .SortTagsAlphabetically()
              .SortOperationsByMethod()
              .PreserveSchemaPropertyOrder()
              .DisableAgent()
              .WithOpenApiRoutePattern(OpenAPIDocumentRoute);
        });
    }
}