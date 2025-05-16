using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Models
{
    public class OwnerExpenseHd : AddCommonEntity
    {
        public int OwnerExpenseId { get; set; }
        public string? OwnerExpenseNo { get; set; }
        public long SaleId { get; set; }
        public string? SaleNo { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte TripNo { get; set; }
        public string? BoatName { get; set; }

        [NotMapped]
        public List<OwnerExpenseDt>? ownerExpensesDts { get; set; }
    }

    [Keyless]
    public class OwnerExpenseDt
    {
        public int OwnerExpenseId { get; set; }
        public string? OwnerExpenseNo { get; set; }
        public byte ItemNo { get; set; }
        public byte SquenceNo { get; set; }
        public string? ExpenseTypeName { get; set; }
        public byte ExpenseTypeId { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}