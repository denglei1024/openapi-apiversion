using OpenApi_ApiVersion.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddUserModule();

var app = builder.Build();

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.MapApiDocumentation();
app.MapControllers();

app.Run();
