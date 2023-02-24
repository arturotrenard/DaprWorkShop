using Dapr.Client;
using System.Text.Json;


var daprClient = new DaprClientBuilder().Build();

const string pubSubName = "pubsub";
const string topicName = "betsnew";

while (true)
{
    var rnd = new Random();
    var bet = new { BetId = rnd.Next(), ToWin = 100, AskRisk = 10 };
    Console.WriteLine("New bet generated: ");

    // How to publish event with Dapr
    await daprClient.PublishEventAsync(pubSubName, topicName, bet);

    Console.WriteLine($"Published data: {JsonSerializer.Serialize(bet)} time: {DateTime.Now.ToShortTimeString()}");
    
    Thread.Sleep(10000);
}


