using System.Text.Json;
using Dapr;
using DaprConsoleClient.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

const string pubSubName = "pubsub";
const string topicName = "betsnew";

builder.Services.AddControllers().AddDapr(conf =>
    conf.UseJsonSerializationOptions(
        new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        }));

var app = builder.Build();

// Dapr will send serialized event object vs. being raw CloudEvent
app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

// Dapr subscription in [Topic] routes orders topic to this route
app.MapPost("/bets", [Topic(pubSubName, topicName)] (BetDto betDto) => {
    Console.WriteLine($"Subscriber received : {JsonSerializer.Serialize(betDto)}");
    return Results.Ok(betDto);
});

await app.RunAsync();
