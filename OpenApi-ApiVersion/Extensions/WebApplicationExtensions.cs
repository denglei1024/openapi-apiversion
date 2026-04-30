using Scalar.AspNetCore;

namespace OpenApi_ApiVersion.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapApiDocumentation(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle("Users API - {documentName}")
                .AddDocuments(new[] { "v1", "v2" });
        });

        return app;
    }
}

