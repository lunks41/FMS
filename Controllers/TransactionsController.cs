using FMS.Data;
using FMS.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Text.Json;
using static Dapper.SqlMapper;

namespace FMS.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ITransaction _transaction;
        private readonly IMaster _master;
        private readonly IDataProtector _protector;
        private readonly IMapper _mapper;
        public TransactionsController(ApplicationDbContext applicationDbContext, ITransaction transaction, IMaster master, IDataProtectionProvider dataProtectionProvider, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _transaction = transaction;
            _master = master;
            _protector = dataProtectionProvider.CreateProtector("Sun@Key");
            _mapper = mapper;
        }

        #region Sale

        public async Task<IActionResult> GetSale(string Fillter)
        {
            var Sales = await _transaction.GetAllSale(Fillter, null, null);
            var model = Sales.Select(s => new SaleHd
            {
                SaleId = s.SaleId,
                EncId = _protector.Protect(s.SaleId.ToString()),
                SaleNo = s.SaleNo,
                TripNo = s.TripNo,
                BoatName = s.BoatName,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                NoOfDays = s.NoOfDays,
                TotalSaleAmount = s.TotalSaleAmount,
                CommisionAmount = s.CommisionAmount,
                TotalExpenseAmount = s.TotalExpenseAmount,
                BalanceAmount = s.BalanceAmount,
                IsActive = s.IsActive,
                CreatedDate = s.CreatedDate
            }).AsEnumerable();

            return View(model);

        }

        public async Task<IActionResult> DefineSale(string eid, string Msg)
        {
            ViewBag.Msg = Msg;
            SaleHd model = new SaleHd();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    var entity = await _transaction.GetByIdAsyncSale(decryptedid);
                    _mapper.Map(entity, model);
                    model.EncId = _protector.Protect(entity.SaleId.ToString());
                }
            }
            else {
                model.StartDate = DateTime.Now;
                model.EndDate = DateTime.Now;
            }
            var boats = await _master.GetAllBoat("", "", 1);
            ViewBag.BoatsList = new SelectList(boats, "BoatId", "BoatName");

            var expensetype = await _master.GetAllExpenseType("","",1);
            ViewBag.ExpenseTypeList = new SelectList(expensetype, "ExpenseTypeId", "ExpenseTypeName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineSale(string eid, string JsonString, string JsonDetails)
        {
            IncomeReponce incomeReponce =new IncomeReponce();  
            SaleHd ObjSale = new SaleHd();
            List<SaleDt> ObjMisExpense = new List<SaleDt>();

            if (!string.IsNullOrEmpty(JsonString) )
            {
                ObjSale = JsonConvert.DeserializeObject<SaleHd>(JsonString)!;

                if (!string.IsNullOrEmpty(JsonDetails))
                    ObjMisExpense = JsonConvert.DeserializeObject<List<SaleDt>>(JsonDetails)!;

                incomeReponce = await _transaction.UpsertAsyncSale(ObjSale);

                if (incomeReponce.Id > 0)
                {
                    foreach (var item in ObjMisExpense!)
                    {
                        item.SaleId = incomeReponce.Id;
                        item.SaleNo = incomeReponce.No;

                        await _transaction.UpsertAsyncSaleDetails(item);
                    }
                }

                ViewBag.Msg = "Data " + (incomeReponce.Id > 0 ? "updated" : "inserted") + " successfully.";
            }

            return Json(System.Text.Json.JsonSerializer.Serialize(incomeReponce));
        }

        [HttpPost]
        public async Task<IActionResult> GetSaleDetailsList(string eid)
        {
            List<SaleDt> entity = new List<SaleDt>();

            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));

                if (decryptedid > 0)
                {
                    var Details = await _transaction.GetByIdAsyncSaleDetails(decryptedid);

                    var model = Details.Select(s => new SaleDt
                    {
                        SaleId = s.SaleId,
                        SaleNo = s.SaleNo,
                        ItemNo = s.ItemNo,
                        SquenceNo = s.SquenceNo,
                        ExpenseTypeName = s.ExpenseTypeName,
                        ExpenseTypeId = s.ExpenseTypeId,
                        MisAmount = s.MisAmount
                    }).ToList();

                    entity = model;
                }
            }
            return Json(System.Text.Json.JsonSerializer.Serialize(entity));
        }

        public async Task<IActionResult> DeleteSale(string eid)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    resultReponce = await _transaction.DeleteAsyncSale(decryptedid, 1);
                }
            }

            ViewBag.Msg = resultReponce.Id > 0 ? "Delete successfully" : resultReponce.Msg;

            return RedirectToAction("GetSale", "Transactions");
        }

        #endregion

        #region Expenses
        //public IActionResult GetExpense() => View();

        public async Task<IActionResult> GetExpense()
        {
            var Sales = await _transaction.GetAllExpense("",null,null);
            var model = Sales.Select(s => new OwnerExpenseHd
            {
                OwnerExpenseId = s.OwnerExpenseId,
                EncId = _protector.Protect(s.OwnerExpenseId.ToString()),
                OwnerExpenseNo = s.OwnerExpenseNo,
                SaleNo = s.SaleNo,
                TotalAmount = s.TotalAmount
            }).AsEnumerable();

            return View(model);

        }

        public async Task<IActionResult> DefineExpense(string eid, string Msg)
        {
            ViewBag.Msg = Msg;
            OwnerExpenseHd model = new OwnerExpenseHd();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    var entity = await _transaction.GetByIdAsyncExpense(decryptedid);
                    _mapper.Map(entity, model);
                    //model.EncId = _protector.Protect(entity.OwnerExpenseId.ToString());
                    model.EncId = eid;
                }
            }
            var sales = await _transaction.GetAllSale("", null, null);
            ViewBag.SaleList = new SelectList(sales, "SaleId", "SaleNo");

            var expensetype = await _master.GetAllExpenseType("", "", 1);
            ViewBag.ExpenseTypeList = new SelectList(expensetype, "ExpenseTypeId", "ExpenseTypeName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineExpense(string eid, string JsonString, string JsonDetails)
        {
            IncomeReponce incomeReponce = new IncomeReponce();
            OwnerExpenseHd ObjOwnerExpenseHd = new OwnerExpenseHd();
            List<OwnerExpenseDt> ObjOwnerExpenseDt = new List<OwnerExpenseDt>();

            if (!string.IsNullOrEmpty(JsonString) && !string.IsNullOrEmpty(JsonDetails))
            {
                ObjOwnerExpenseHd = JsonConvert.DeserializeObject<OwnerExpenseHd>(JsonString)!;
                ObjOwnerExpenseDt = JsonConvert.DeserializeObject<List<OwnerExpenseDt>>(JsonDetails)!;

                incomeReponce = await _transaction.UpsertAsyncExpense(ObjOwnerExpenseHd);

                if (incomeReponce.Id > 0)
                {
                    foreach (var item in ObjOwnerExpenseDt!)
                    {
                        item.OwnerExpenseId = incomeReponce.Id;
                        item.OwnerExpenseNo = incomeReponce.No;

                        await _transaction.UpsertAsyncExpenseDetails(item);
                    }
                }

                ViewBag.Msg = "Data " + (incomeReponce.Id > 0 ? "updated" : "inserted") + " successfully.";
            }

            return Json(System.Text.Json.JsonSerializer.Serialize(incomeReponce));
        }

        [HttpPost]
        public async Task<IActionResult> GetExpenseDetailsList(string eid)
        {
            List<OwnerExpenseDt> entity = new List<OwnerExpenseDt>();

            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));

                if (decryptedid > 0)
                {
                    var Details = await _transaction.GetByIdAsyncExpenseDetails(decryptedid);

                    var model = Details.Select(s => new OwnerExpenseDt
                    {
                        OwnerExpenseId = s.OwnerExpenseId,
                        OwnerExpenseNo = s.OwnerExpenseNo,
                        ItemNo = s.ItemNo,
                        SquenceNo = s.SquenceNo,
                        ExpenseTypeName = s.ExpenseTypeName,
                        ExpenseTypeId = s.ExpenseTypeId,
                        Qty = s.Qty,
                        Price = s.Price,
                        Amount = s.Amount
                    }).ToList();

                    entity = model;
                }
            }
            return Json(System.Text.Json.JsonSerializer.Serialize(entity));
        }

        public async Task<IActionResult> DeleteExpense(string eid)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    resultReponce = await _transaction.DeleteAsyncExpense(decryptedid, 1);
                }
            }

            ViewBag.Msg = resultReponce.Id > 0 ? "Delete successfully" : resultReponce.Msg;

            return RedirectToAction("GetExpense", "Transactions");
        }


        #endregion

        #region Incomes

        public async Task<IActionResult> GetIncome()
        {
            var Sales = await _transaction.GetAllIncome("",null,null);
            var model = Sales.Select(s => new IncomeHd
            {
                IncomeId = s.IncomeId,
                EncId = _protector.Protect(s.IncomeId.ToString()),
                IncomeNo = s.IncomeNo,
                SaleNo = s.SaleNo,
                TotalAmount = s.TotalAmount
            }).AsEnumerable();

            return View(model);

        }

        public async Task<IActionResult> DefineIncome(string eid, string Msg)
        {
            ViewBag.Msg = Msg;
            IncomeHd model = new IncomeHd();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    var entity = await _transaction.GetByIdAsyncIncome(decryptedid);
                    _mapper.Map(entity, model);
                    model.EncId = _protector.Protect(entity.IncomeId.ToString());
                }
            }
            var sales = await _transaction.GetAllSale("", null, null);
            ViewBag.SaleList = new SelectList(sales, "SaleId", "SaleNo");

            var CommissionType = await _master.GetAllCommissionType("", "", 1);
            ViewBag.CommissionTypeList = new SelectList(CommissionType, "CommissionTypeId", "CommissionTypeName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineIncome(string eid, string JsonString, string JsonDetails)
        {
            IncomeReponce incomeReponce = new IncomeReponce();
            IncomeHd ObjIncomeHd = new IncomeHd();
            List<IncomeDt> ObjIncomeDt = new List<IncomeDt>();

            if (!string.IsNullOrEmpty(JsonString) && !string.IsNullOrEmpty(JsonDetails))
            {
                ObjIncomeHd = JsonConvert.DeserializeObject<IncomeHd>(JsonString)!;
                ObjIncomeDt = JsonConvert.DeserializeObject<List<IncomeDt>>(JsonDetails)!;

                incomeReponce = await _transaction.UpsertAsyncIncome(ObjIncomeHd);

                if (incomeReponce.Id > 0)
                {
                    foreach (var item in ObjIncomeDt!)
                    {
                        item.IncomeId = incomeReponce.Id;
                        item.IncomeNo = incomeReponce.No;

                        await _transaction.UpsertAsyncIncomeDetails(item);
                    }
                }

                ViewBag.Msg = "Data " + (incomeReponce.Id > 0 ? "updated" : "inserted") + " successfully.";
            }

            return Json(System.Text.Json.JsonSerializer.Serialize(incomeReponce));
        }

        [HttpPost]
        public async Task<IActionResult> GetIncomeDetailsList(string eid)
        {
            List<IncomeDt> entity = new List<IncomeDt>();

            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));

                if (decryptedid > 0)
                {
                    var Details = await _transaction.GetByIdAsyncIncomeDetails(decryptedid);

                    var model = Details.Select(s => new IncomeDt
                    {
                        IncomeId = s.IncomeId,
                        IncomeNo = s.IncomeNo,
                        ItemNo = s.ItemNo,
                        SquenceNo = s.SquenceNo,
                        CommissionTypeId = s.CommissionTypeId,
                        CommissionTypeName = s.CommissionTypeName,
                        Qty = s.Qty,
                        Price = s.Price,
                        Amount = s.Amount
                    }).ToList();

                    entity = model;
                }
            }
            return Json(System.Text.Json.JsonSerializer.Serialize(entity));
        }

        public async Task<IActionResult> DeleteIncome(string eid)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    resultReponce = await _transaction.DeleteAsyncIncome(decryptedid, 1);
                }
            }

            ViewBag.Msg = resultReponce.Id > 0 ? "Delete successfully" : resultReponce.Msg;

            return RedirectToAction("GetIncome", "Transactions");
        }
        #endregion

        #region Credits
        public async Task<IActionResult> GetCredit()
        {
            var Sales = await _transaction.GetAllCredit("", "");
            var model = Sales.Select(s => new CreditHd
            {
                CreditId = s.CreditId,
                EncId = _protector.Protect(s.CreditId.ToString()),
                CreditNo = s.CreditNo,
                BoatName = s.BoatName,
                PersonName = s.PersonName,
                TotalDebitAmount = s.TotalDebitAmount,
                TotalCreditAmount = s.TotalCreditAmount,
                TotalBalanceAmount = s.TotalBalanceAmount
            }).AsEnumerable();

            return View(model);

        }

        public async Task<IActionResult> DefineCredit(string eid, string Msg)
        {
            ViewBag.Msg = Msg;
            CreditHd model = new CreditHd();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    var entity = await _transaction.GetByIdAsyncCredit(decryptedid);
                    _mapper.Map(entity, model);
                    model.EncId = _protector.Protect(entity.CreditId.ToString());
                }
            }
            

            var boats = await _master.GetAllBoat("", "", 1);
            ViewBag.BoatsList = new SelectList(boats, "BoatId", "BoatName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineCredit(string eid, string JsonString, string JsonDetails)
        {
            IncomeReponce incomeReponce = new IncomeReponce();
            CreditHd ObjCreditHd = new CreditHd();
            List<CreditDt> ObjCreditDt = new List<CreditDt>();

            if (!string.IsNullOrEmpty(JsonString))
            {
                ObjCreditHd = JsonConvert.DeserializeObject<CreditHd>(JsonString)!;

                if (!string.IsNullOrEmpty(JsonDetails))
                    ObjCreditDt = JsonConvert.DeserializeObject<List<CreditDt>>(JsonDetails)!;

                incomeReponce = await _transaction.UpsertAsyncCredit(ObjCreditHd);

                if (incomeReponce.Id > 0)
                {
                    foreach (var item in ObjCreditDt!)
                    {
                        item.CreditId = incomeReponce.Id;
                        item.CreditNo = incomeReponce.No;

                        await _transaction.UpsertAsyncCreditDetails(item);
                    }
                }

                ViewBag.Msg = "Data " + (incomeReponce.Id > 0 ? "updated" : "inserted") + " successfully.";
            }

            return Json(System.Text.Json.JsonSerializer.Serialize(incomeReponce));
        }

        [HttpPost]
        public async Task<IActionResult> GetCreditDetailsList(string eid)
        {
            List<CreditDt> entity = new List<CreditDt>();

            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));

                if (decryptedid > 0)
                {
                    var Details = await _transaction.GetByIdAsyncCreditDetails(decryptedid);

                    var model = Details.Select(s => new CreditDt
                    {
                        CreditId = s.CreditId,
                        CreditNo = s.CreditNo,
                        ItemNo = s.ItemNo,
                        SquenceNo = s.SquenceNo,
                        PaymentDate = s.PaymentDate,
                        DebitAmount = s.DebitAmount,
                        CreditAmount = s.CreditAmount
                    }).ToList();

                    entity = model;
                }
            }
            return Json(System.Text.Json.JsonSerializer.Serialize(entity));
        }

        public async Task<IActionResult> DeleteCredit(string eid)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    resultReponce = await _transaction.DeleteAsyncCredit(decryptedid, 1);
                }
            }

            ViewBag.Msg = resultReponce.Id > 0 ? "Delete successfully" : resultReponce.Msg;

            return RedirectToAction("GetCredit", "Transactions");
        }
        #endregion
    }
}
