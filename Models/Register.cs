using System.ComponentModel.DataAnnotations;

namespace FMS.Models
{
    public class Register
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passsword does not Match.")]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.Password)]
        public string? PhoneNumber { get; set; }
    }
}