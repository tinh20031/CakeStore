using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CakeStoreAPI.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name must not exceed 100 characters")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
        public string? Size { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        [Required(ErrorMessage = "Stock quantity is required")]
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Boolean Available { get; set; } = true;
        public DateTimeOffset Created_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated_At { get; set; } = DateTimeOffset.UtcNow;
        [JsonIgnore]
        public virtual Category? Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<PromotionProducts>? PromotionProducts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reviews>? Reviews { get; set; }


    }
}
