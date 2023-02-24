using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

//Inject the Dapr service into the application
builder.Services.AddControllers().AddDapr(conf =>
    conf.UseJsonSerializationOptions(
        new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        }));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.UseRouting();

// Dapr will send serialized event object vs. being raw CloudEvent
app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

app.MapControllers();

await app.RunAsync();