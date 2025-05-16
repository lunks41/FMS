namespace FMS.Models
{
    public class CommissionType : AddCommonEntity
    {
        public int CommissionTypeId { get; set; }
        public string? CommissionTypeCode { get; set; }
        public string? CommissionTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}