namespace FMS.Models
{
    public class CommissionReport
    {

        public byte IncomeId { get; set; }
        public string? SaleNo { get; set; }
        public string? BoatName { get; set; }
        public decimal QtyIce { get; set; }
        public decimal PriceIce { get; set; }
        public decimal AmountIce { get; set; }
        public decimal QtyFuel { get; set; }
        public decimal PriceFuel { get; set; }
        public decimal AmountFuel { get; set; }
        public decimal QtyFertizer { get; set; }
        public decimal PriceFertizer { get; set; }
        public decimal AmountFertizer { get; set; }
        public decimal QtyShare { get; set; }
        public decimal PriceShare { get; set; }
        public decimal AmountShare { get; set; }
        public decimal QtyOwner { get; set; }
        public decimal PriceOwner { get; set; }
        public decimal AmountOwner { get; set; }
    }
}
