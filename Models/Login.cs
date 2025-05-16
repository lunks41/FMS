using System.ComponentModel.DataAnnotations;

namespace FMS.Models
{
    public class Login
    {
        [Required]
        [MaxLength(15)]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool KeepLoggedIn { get; set; }
    }
}