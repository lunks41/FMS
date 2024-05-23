using Microsoft.AspNetCore.Mvc;
using FMS.Models;
using Microsoft.AspNetCore.Authorization;
using FMS.Data;

namespace FMS.Controllers;

[Authorize]
public class ReportController : Controller
{
    private readonly ILogger<ReportController> _logger;
    private readonly ITransaction _transaction;
    private readonly IReport _report;

    public ReportController(ILogger<ReportController> logger, ITransaction transaction, IReport report)
    {
        _logger = logger;
        _transaction = transaction;
        _report = report;
    }

    public IActionResult GetReport()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetSaleReportList(string Search)
    {
        List<SaleHd> entity = new List<SaleHd>();

        var Sales = await _transaction.GetAllSale(Search);

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
    public async Task<IActionResult> GetExpenseReportList(string Search)
    {
        List<OwnerExpenseHd> entity = new List<OwnerExpenseHd>();

        var Sales = await _transaction.GetAllExpense(Search);

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
    public async Task<IActionResult> GetIncomeReportList(string Search)
    {
        List<IncomeHd> entity = new List<IncomeHd>();

        var Sales = await _transaction.GetAllIncome(Search);

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
    public async Task<IActionResult> GetPnlReportList(string Search)
    {
        List<Pnl> entity = new List<Pnl>();

        var Sales = await _report.GetAllPnl(Search);

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
}
