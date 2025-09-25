using CakeStore.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeStoreAPI.Models
{

    public enum RoleType
    {
        Customer,
        Admin
    }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username must not exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required")]  
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public RoleType Role { get; set; } = RoleType.Customer;
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Address { get; set; }
 
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public string? RefreshToken { get; set; }
        public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
        public DateTimeOffset Created_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated_At { get; set; } = DateTimeOffset.UtcNow;
        public virtual ICollection<Orders>? Orders { get; set; }
        public virtual ICollection<Reviews>? Reviews { get; set; }
        public virtual Cart? Cart { get; set; }


    }
}
