using Asp.Versioning;
using OpenApi_ApiVersion.Services.Users;

namespace OpenApi_ApiVersion.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddProblemDetails();

        services.AddControllers();

        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddOpenApi("v1", options =>
        {
            options.ShouldInclude = apiDescription => apiDescription.GroupName == "v1";
        });

        services.AddOpenApi("v2", options =>
        {
            options.ShouldInclude = apiDescription => apiDescription.GroupName == "v2";
        });

        return services;
    }

    public static IServiceCollection AddUserModule(this IServiceCollection services)
    {
        services.AddSingleton<IUserQueryService, InMemoryUserQueryService>();

        return services;
    }
}

