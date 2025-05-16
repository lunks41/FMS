namespace FMS.Models
{
    public class RemarkEntry : AddCommonEntity
    {
        public int RemarkEntryId { get; set; }
        public string? RemarkEntryNo { get; set; }
        public int BoatId { get; set; }
        public DateTime AccountDate { get; set; }
        public string? BoatName { get; set; }
        public string? Remarks { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}