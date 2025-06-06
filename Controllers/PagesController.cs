using Microsoft.AspNetCore.Mvc;

namespace FMS.Controllers;

public class PagesController : Controller
{
    public IActionResult AccountSettings() => View();

    public IActionResult AccountSettingsConnections() => View();

    public IActionResult AccountSettingsNotifications() => View();

    //[Route("404")]
    public IActionResult MiscError() => View();

    public IActionResult MiscUnderMaintenance() => View();

    //[Route("505")]
    public IActionResult MiscServiceError() => View();
}