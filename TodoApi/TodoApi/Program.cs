using Microsoft.Azure.Cosmos;
using TodoApi;
using static TodoApi.IQuestionService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<CosmosClient>(sp =>
{
    string endpointUrl = "your-cosmos-db-endpoint-url";
    string primaryKey = "your-cosmos-db-primary-key";
    return new CosmosClient(endpointUrl, primaryKey);
});

builder.Services.AddScoped<ITodoRepository, CosmosDbTodoRepository>(); // Register repository
builder.Services.AddScoped<ITodoService, TodoService>(); // Register service
                                                         // Register Cosmos DB repository
//builder.Services.AddSingleton<IQuestionRepository, CosmosQuestionRepository>();

// Register the service
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
