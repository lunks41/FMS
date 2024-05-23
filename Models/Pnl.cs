using System.ComponentModel.DataAnnotations;

namespace FMS.Models
{
    public class Pnl
    {
        public byte TripNo { get; set; }
        public string? SaleNo { get; set; }
        public string? BoatName { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Totalpnl { get; set; }
    }
}
