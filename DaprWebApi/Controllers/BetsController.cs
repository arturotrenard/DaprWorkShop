using Dapr;
using DaprWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DaprWebApi.Controllers;

[ApiController]
public class BetsController : Controller
{
    private ILogger _logger;
    
    const string PubSubName = "pubsub";
    const string TopicName = "betsnew";

    public BetsController(ILogger<BetsController> logger)
    {
        _logger = logger;
    }
    
    //Subscribe to a topic 
    [Topic(PubSubName, TopicName)]
    [HttpPost("bets")]
    public IActionResult Do(BetDto bet)
    {
        _logger.LogInformation($"the bet arrived: {JsonSerializer.Serialize(bet)}");

        return Ok();
    }
}