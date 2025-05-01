using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddWeatherServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API v1")
    );
}

// Configure routes
app.MapWeatherRoutes();
app.UseRouting();
app.UseEndpoints(endpoints => { });

app.Run();
