using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace PaperStore.Controllers;

[Route("api/[Controller]")]
public class HealthController(ILogger<ActualInventoryController> logger, HealthCheckService services) : Controller
{
    ILogger<ActualInventoryController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    HealthCheckService _services = services;

    [HttpGet]
    public async Task<IActionResult> CheckApiHealth()
    {
        var HealthCheck = await _services.CheckHealthAsync();
        _logger.LogInformation($"Api Health: {HealthCheck.Status}");


        return HealthCheck.Status == HealthStatus.Healthy ?
            Ok(HealthCheck.Status) :
            StatusCode((int)HttpStatusCode.InternalServerError, HealthCheck.Status);
    }
}

