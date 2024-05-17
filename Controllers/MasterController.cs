using FMS.Data;
using FMS.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static Dapper.SqlMapper;

namespace FMS.Controllers
{
    public class MasterController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMaster _master;
        private readonly IDataProtector _protector;
        private readonly IMapper _mapper;
        public MasterController(ApplicationDbContext applicationDbContext, IMaster master, IDataProtectionProvider dataProtectionProvider, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _master = master;
            _protector = dataProtectionProvider.CreateProtector("Sun@Key");
            _mapper = mapper;
        }

        #region Boat
        public async Task<IActionResult> GetBoat(string BoatCode, string BoatName, int? IsActive)
        {
            var boats = await _master.GetAllBoat(BoatCode, BoatName, IsActive);
            var model = boats.Select(s => new Boat
            {
                BoatId = s.BoatId,
                EncId = _protector.Protect(s.BoatId.ToString()),
                BoatCode = s.BoatCode,
                BoatName = s.BoatName,
                IsActive = s.IsActive,
                CreatedDate = s.CreatedDate
            }).AsEnumerable();

            return View(model);

        }

        public async Task<IActionResult> DefineBoat(string eid, string Msg)
        {
            ViewBag.Msg = Msg;
            Boat model = new Boat();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    var entity = await _master.GetByIdAsyncBoat(decryptedid);
                    _mapper.Map(entity, model);
                    model.EncId = _protector.Protect(entity.BoatId.ToString());
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineBoat(Boat model)
        {
            Boat entity;
            if (ModelState.IsValid)
            {
                if (model.BoatId > 0)
                {
                    entity = await _master.GetByIdAsyncBoat(model.BoatId);
                    _mapper.Map(model, entity);
                    //entity.UpdatedBy = General.GetUserID();
                    entity.UpdatedBy = 1;
                    entity.CreatedBy = 1;
                    entity.UpdatedDate = DateTime.Now;
                }
                else
                {
                    entity = _mapper.Map<Boat>(model);
                    //entity.CreatedBy = General.GetUserID();
                    entity.CreatedBy = 1;
                }
                entity = await _master.UpsertAsyncBoat(entity);
                ViewBag.Msg = "Data " + (entity.BoatId > 0 ? "updated" : "inserted") + " successfully.";
                model.EncId = _protector.Protect(entity.BoatId.ToString());

                ModelState.Clear();
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteBoat(string eid)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    resultReponce = await _master.DeleteAsyncBoat(decryptedid, 1);
                }
            }

            ViewBag.Msg = resultReponce.Id > 0 ? "Delete successfully" : resultReponce.Msg;

            return RedirectToAction("GetBoat", "Master");
            //return resultReponce.Id > 0 ? Content("success") : Content("error");
        }
        #endregion

        #region ExpenseType
        public async Task<IActionResult> GetExpenseType(string ExpenseTypeCode, string ExpenseTypeName, int? IsActive)
        {
            var ExpenseTypes = await _master.GetAllExpenseType(ExpenseTypeCode, ExpenseTypeName, IsActive);
            var model = ExpenseTypes.Select(s => new ExpenseType
            {
                ExpenseTypeId = s.ExpenseTypeId,
                EncId = _protector.Protect(s.ExpenseTypeId.ToString()),
                ExpenseTypeCode = s.ExpenseTypeCode,
                ExpenseTypeName = s.ExpenseTypeName,
                IsActive = s.IsActive,
                CreatedDate = s.CreatedDate
            }).AsEnumerable();

            return View(model);

        }

        public async Task<IActionResult> DefineExpenseType(string eid, string Msg)
        {
            ViewBag.Msg = Msg;
            ExpenseType model = new ExpenseType();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    var entity = await _master.GetByIdAsyncExpenseType(decryptedid);
                    _mapper.Map(entity, model);
                    model.EncId = _protector.Protect(entity.ExpenseTypeId.ToString());
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineExpenseType(ExpenseType model)
        {
            ExpenseType entity;
            if (ModelState.IsValid)
            {
                if (model.ExpenseTypeId > 0)
                {
                    entity = await _master.GetByIdAsyncExpenseType(model.ExpenseTypeId);
                    _mapper.Map(model, entity);
                    //entity.UpdatedBy = General.GetUserID();
                    entity.UpdatedBy = 1;
                    entity.CreatedBy = 1;
                    entity.UpdatedDate = DateTime.Now;
                }
                else
                {
                    entity = _mapper.Map<ExpenseType>(model);
                    //entity.CreatedBy = General.GetUserID();
                    entity.CreatedBy = 1;
                }
                entity = await _master.UpsertAsyncExpenseType(entity);
                ViewBag.Msg = "Data " + (entity.ExpenseTypeId > 0 ? "updated" : "inserted") + " successfully.";
                model.EncId = _protector.Protect(entity.ExpenseTypeId.ToString());

                ModelState.Clear();
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteExpenseType(string eid)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    resultReponce = await _master.DeleteAsyncExpenseType(decryptedid, 1);
                }
            }

            ViewBag.Msg = resultReponce.Id > 0 ? "Delete successfully" : resultReponce.Msg;

            return RedirectToAction("GetExpenseType", "Master");
        }
        #endregion

        #region CommissionType
        public async Task<IActionResult> GetCommissionType(string CommissionTypeCode, string CommissionTypeName, int? IsActive)
        {
            var CommissionTypes = await _master.GetAllCommissionType(CommissionTypeCode, CommissionTypeName, IsActive);
            var model = CommissionTypes.Select(s => new CommissionType
            {
                CommissionTypeId = s.CommissionTypeId,
                EncId = _protector.Protect(s.CommissionTypeId.ToString()),
                CommissionTypeCode = s.CommissionTypeCode,
                CommissionTypeName = s.CommissionTypeName,
                IsActive = s.IsActive,
                CreatedDate = s.CreatedDate
            }).AsEnumerable();

            return View(model);

        }

        public async Task<IActionResult> DefineCommissionType(string eid, string Msg)
        {
            ViewBag.Msg = Msg;
            CommissionType model = new CommissionType();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    var entity = await _master.GetByIdAsyncCommissionType(decryptedid);
                    _mapper.Map(entity, model);
                    model.EncId = _protector.Protect(entity.CommissionTypeId.ToString());
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineCommissionType(CommissionType model)
        {
            CommissionType entity;
            if (ModelState.IsValid)
            {
                if (model.CommissionTypeId > 0)
                {
                    entity = await _master.GetByIdAsyncCommissionType(model.CommissionTypeId);
                    _mapper.Map(model, entity);
                    //entity.UpdatedBy = General.GetUserID();
                    entity.UpdatedBy = 1;
                    entity.CreatedBy = 1;
                    entity.UpdatedDate = DateTime.Now;
                }
                else
                {
                    entity = _mapper.Map<CommissionType>(model);
                    //entity.CreatedBy = General.GetUserID();
                    entity.CreatedBy = 1;
                }
                entity = await _master.UpsertAsyncCommissionType(entity);
                ViewBag.Msg = "Data " + (entity.CommissionTypeId > 0 ? "updated" : "inserted") + " successfully.";
                model.EncId = _protector.Protect(entity.CommissionTypeId.ToString());

                ModelState.Clear();
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteCommissionType(string eid)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            if (!string.IsNullOrEmpty(eid))
            {
                var decryptedid = General.ConvertToInt(_protector.Unprotect(eid));
                if (decryptedid > 0)
                {
                    resultReponce = await _master.DeleteAsyncCommissionType(decryptedid, 1);
                }
            }

            ViewBag.Msg = resultReponce.Id > 0 ? "Delete successfully" : resultReponce.Msg;

            return RedirectToAction("GetCommissionType", "Master");
        }
        #endregion
    }
}
