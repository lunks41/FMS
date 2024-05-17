namespace FMS.Models
{
    public class Boat : AddCommonEntity
    {
        public int BoatId { get; set; }
        public string? BoatCode { get; set; }
        public string? BoatName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
