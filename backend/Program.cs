var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

Graph<int> graph = new Graph<int>();
var node1 = new GraphNode<int> { Value = 1 };
var node2 = new GraphNode<int> { Value = 2 };
var node3 = new GraphNode<int> { Value = 3 };
var node4 = new GraphNode<int> { Value = 4 };
graph.AddNode(node1);
graph.AddNode(node2);
graph.AddNode(node3);
graph.AddNode(node4);
graph.AddEdge(node1, node2, 1);
graph.AddEdge(node1, node3, 2);
graph.AddEdge(node2, node3, 3);
graph.AddEdge(node3, node4, 4);

Console.WriteLine(graph);

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
