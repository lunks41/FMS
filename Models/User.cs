using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Models
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string? Name { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime LastLogin { get; set; } = DateTime.Now;

        public bool IsAdmin { get; set; } = false;
    }
}