using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeStoreAPI.Models
{
    public class Promotions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PromotionId { get; set; }
        [Required(ErrorMessage = "Promotion name is required")]
        [StringLength(100, ErrorMessage = "Promotion name must not exceed 100 characters")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
        public string Description { get; set; }
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddMonths(1));
        [Required(ErrorMessage = "Discount percentage is required")]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100")]
        public decimal DiscountPercentage { get; set; }
        public string Code { get; set; }
        public DateTimeOffset Created_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated_At { get; set; } = DateTimeOffset.UtcNow;
        public virtual ICollection<PromotionProducts>? PromotionProducts { get; set; }
        public virtual ICollection<PromotionHistory>? PromotionHistories { get; set; }
    }
}
