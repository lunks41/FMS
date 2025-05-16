using FMS.Data;
using FMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Controllers;

[Authorize]
public class DashboardsController : Controller
{
    private readonly ILogger<ReportController> _logger;
    private readonly IReport _report;

    public DashboardsController(ILogger<ReportController> logger, IReport report)
    {
        _logger = logger;
        _report = report;
    }

    public async Task<IActionResult> Index() => View();

    [HttpPost]
    public async Task<IActionResult> GetDashboard()
    {
        List<Dashboard> entity = new List<Dashboard>();

        var Sales = await _report.GetDashboard();
        var model = Sales.Select(s => new Dashboard
        {
            BoatId = s.BoatId,
            BoatName = s.BoatName,
            TotalAmount = s.TotalAmount,
            Name = s.Name,
            FertizilerAmount = s.FertizilerAmount,
            Ownershare = s.Ownershare,
            Fuelamount = s.Fuelamount
        }).ToList();

        entity = model;

        return Json(System.Text.Json.JsonSerializer.Serialize(entity));
    }
}