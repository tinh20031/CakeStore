using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeStoreAPI.Models
{
    public enum PromotionChangeType
    {
        Created,
        Updated,
        Deleted,
        Activated,
        Deactivated
    }

    public class PromotionHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PromotionHistoryId { get; set; }
        public int PromotionId { get; set; }
        public PromotionChangeType Action { get; set; }
        public string Change_By { get; set; }
        public DateTimeOffset Change_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Created_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated_At { get; set; } = DateTimeOffset.UtcNow;
        public virtual Promotions? Promotion { get; set; }
    }
}
