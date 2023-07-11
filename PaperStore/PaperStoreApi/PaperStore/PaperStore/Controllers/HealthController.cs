using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace PaperStore.Controllers;

[Route("api/[Controller]")]
public class HealthController(ILogger<ActualInventoryController> logger, HealthCheckService services) : Controller
{
    ILogger<ActualInventoryController> Logger { get; init; } = logger ?? throw new ArgumentNullException(nameof(logger));

    HealthCheckService Services { get; init; } = services;

    [HttpGet]
    public async Task<IActionResult> CheckApiHealth()
    {
        var HealthCheck = await Services.CheckHealthAsync();
        Logger.LogInformation($"Api Health: {HealthCheck.Status}");


        return HealthCheck.Status == HealthStatus.Healthy ?
            Ok(HealthCheck.Status) :
            StatusCode((int)HttpStatusCode.InternalServerError, HealthCheck.Status);
    }
}

