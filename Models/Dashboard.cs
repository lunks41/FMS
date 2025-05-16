namespace FMS.Models
{
    public class Dashboard
    {
        public byte BoatId { get; set; }
        public string? BoatName { get; set; }
        public string? TotalAmount { get; set; }
        public string? Name { get; set; }
        public decimal? FertizilerAmount { get; set; }
        public decimal? Ownershare { get; set; }
        public decimal? Fuelamount { get; set; }
    }
}