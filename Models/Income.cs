using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Models
{
    public class IncomeHd : AddCommonEntity
    {
        public int IncomeId { get; set; }
        public string? IncomeNo { get; set; }
        public long SaleId { get; set; }
        public string? SaleNo { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte TripNo { get; set; }
        public string? BoatName { get; set; }

        [NotMapped]
        public ICollection<IncomeDt>? IncomesDts { get; set; }
    }

    [Keyless]
    public class IncomeDt
    {
        public int IncomeId { get; set; }
        public string? IncomeNo { get; set; }
        public byte ItemNo { get; set; }
        public byte SquenceNo { get; set; }
        public byte CommissionTypeId { get; set; }
        public string? CommissionTypeName { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}