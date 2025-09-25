using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeStoreAPI.Models
{
    public class Reviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "You must provide a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [StringLength(500, ErrorMessage = "Comment must not exceed 500 characters")]
        public string Comment { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTimeOffset ReviewDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Created_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated_At { get; set; } = DateTimeOffset.UtcNow;
        public virtual Products? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
