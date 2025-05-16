namespace FMS.Models
{
    public class ExpenseType : AddCommonEntity
    {
        public int ExpenseTypeId { get; set; }
        public string? ExpenseTypeCode { get; set; }
        public string? ExpenseTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}