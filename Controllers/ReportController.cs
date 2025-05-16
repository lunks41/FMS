using FMS.Data;
using FMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FMS.Controllers;

[Authorize]
public class ReportController : Controller
{
    private readonly ILogger<ReportController> _logger;
    private readonly IMaster _master;
    private readonly IReport _report;

    public ReportController(ILogger<ReportController> logger, IMaster master, IReport report)
    {
        _logger = logger;
        _master = master;
        _report = report;
    }

    public async Task<IActionResult> GetReport()
    {
        var boats = await _master.GetAllBoat("", "", 1);
        ViewBag.BoatsList = new SelectList(boats, "BoatId", "BoatName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetSaleReportList(string Search, int BoatId, DateTime StartDate, DateTime EndDate)
    {
        List<SaleHd> entity = new List<SaleHd>();

        var Sales = await _report.GetAllSaleReport(Search, StartDate, EndDate, BoatId);

        var model = Sales.Select(s => new SaleHd
        {
            TripNo = s.TripNo,
            SaleNo = s.SaleNo,
            BoatName = s.BoatName,
            TotalSaleAmount = s.TotalSaleAmount,
            TotalExpenseAmount = s.TotalExpenseAmount,
            BalanceAmount = s.BalanceAmount
        }).ToList();

        entity = model;

        return Json(System.Text.Json.JsonSerializer.Serialize(entity));
    }

    [HttpPost]
    public async Task<IActionResult> GetExpenseReportList(string Search, int BoatId, DateTime StartDate, DateTime EndDate)
    {
        List<OwnerExpenseHd> entity = new List<OwnerExpenseHd>();

        var Sales = await _report.GetAllExpenseReport(Search, StartDate, EndDate, BoatId);

        var model = Sales.Select(s => new OwnerExpenseHd
        {
            TripNo = s.TripNo,
            SaleNo = s.SaleNo,
            BoatName = s.BoatName,
            OwnerExpenseNo = s.OwnerExpenseNo,
            TotalAmount = s.TotalAmount
        }).ToList();

        entity = model;

        return Json(System.Text.Json.JsonSerializer.Serialize(entity));
    }

    [HttpPost]
    public async Task<IActionResult> GetIncomeReportList(string Search, int BoatId, DateTime StartDate, DateTime EndDate)
    {
        List<IncomeHd> entity = new List<IncomeHd>();

        var Sales = await _report.GetAllIncomeReport(Search, StartDate, EndDate, BoatId);

        var model = Sales.Select(s => new IncomeHd
        {
            TripNo = s.TripNo,
            SaleNo = s.SaleNo,
            BoatName = s.BoatName,
            IncomeNo = s.IncomeNo,
            TotalAmount = s.TotalAmount,
            BalanceAmount = s.BalanceAmount
        }).ToList();

        entity = model;

        return Json(System.Text.Json.JsonSerializer.Serialize(entity));
    }

    [HttpPost]
    public async Task<IActionResult> GetPnlReportList(string Search, int BoatId, DateTime StartDate, DateTime EndDate)
    {
        List<Pnl> entity = new List<Pnl>();

        var Sales = await _report.GetAllPnl(Search, StartDate, EndDate, BoatId);

        var model = Sales.Select(s => new Pnl
        {
            TripNo = s.TripNo,
            SaleNo = s.SaleNo,
            BoatName = s.BoatName,
            TotalExpense = s.TotalExpense,
            TotalIncome = s.TotalIncome,
            Totalpnl = s.Totalpnl
        }).ToList();

        entity = model;

        return Json(System.Text.Json.JsonSerializer.Serialize(entity));
    }

    [HttpPost]
    public async Task<IActionResult> GetCommissionReportList(string Search, int BoatId, DateTime StartDate, DateTime EndDate)
    {
        List<CommissionReport> entity = new List<CommissionReport>();

        var Sales = await _report.GetAllCommission(Search, StartDate, EndDate, BoatId);

        var model = Sales.Select(s => new CommissionReport
        {
            IncomeId = s.IncomeId,
            SaleNo = s.SaleNo,
            BoatName = s.BoatName,
            QtyFertizer = s.QtyFertizer,
            QtyFuel = s.QtyFuel,
            QtyIce = s.QtyIce,
            QtyOwner = s.QtyOwner,
            QtyShare = s.QtyShare,
            PriceFertizer = s.PriceFertizer,
            PriceFuel = s.PriceFuel,
            PriceIce = s.PriceIce,
            PriceOwner = s.PriceOwner,
            PriceShare = s.PriceShare,
            AmountFertizer = s.AmountFertizer,
            AmountFuel = s.AmountFuel,
            AmountIce = s.AmountIce,
            AmountOwner = s.AmountOwner,
            AmountShare = s.AmountShare
        }).ToList();

        entity = model;

        return Json(System.Text.Json.JsonSerializer.Serialize(entity));
    }
}