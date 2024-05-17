using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace FMS.Controllers;

[Authorize]
public class DashboardsController : Controller
{
  public IActionResult Index() => View();
}
