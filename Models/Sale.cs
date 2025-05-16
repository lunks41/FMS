using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Models
{
    public class SaleHd : AddCommonEntity
    {
        [Key]
        public long SaleId { get; set; }

        public string? SaleNo { get; set; }
        public int BoatId { get; set; }
        public string? BoatName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte TripNo { get; set; }
        public int NoOfDays { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public decimal CommisionAmount { get; set; }
        public decimal TempleAmount { get; set; }
        public decimal IceQty { get; set; }
        public decimal IcePrice { get; set; }
        public decimal IceAmount { get; set; }
        public decimal FuelQty { get; set; }
        public decimal FuelPrice { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FoodAmount { get; set; }
        public decimal MiscellaneousAmount { get; set; }
        public decimal HelperAmount { get; set; }
        public decimal BataNoOfPerson { get; set; }
        public decimal BataPerDayAmount { get; set; }
        public decimal BataAmount { get; set; }
        public decimal DrinkingWaterAmount { get; set; }
        public decimal SrankAmount { get; set; }
        public decimal CPhoneRechargeAmount { get; set; }
        public decimal BerthAmount { get; set; }
        public decimal CookingGasAmount { get; set; }
        public decimal OilChnageAmount { get; set; }
        public decimal TabRechargeAmount { get; set; }
        public decimal TotalExpenseAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        [NotMapped]
        public List<SaleDt> ObjSaleDt { get; set; }
    }

    [Keyless]
    public class SaleDt
    {
        public long SaleId { get; set; }
        public string? SaleNo { get; set; }
        public byte ItemNo { get; set; }
        public byte SquenceNo { get; set; }
        public byte ExpenseTypeId { get; set; }
        public string? ExpenseTypeName { get; set; }
        public decimal MisAmount { get; set; }
    }
}