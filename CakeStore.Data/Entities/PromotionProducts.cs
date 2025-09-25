using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeStoreAPI.Models
{
    public class PromotionProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PromotionProductsId { get; set; }
        public int PromotionId { get; set; }
        public int ProductId { get; set; }
        public DateTimeOffset Created_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated_At { get; set; } = DateTimeOffset.UtcNow;
        public virtual Promotions? Promotion { get; set; }
        public virtual Products? Product { get; set; }
    }
}
