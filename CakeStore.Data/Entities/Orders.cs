using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeStoreAPI.Models
{
    public enum status
    {
        Pending,
        Confirmed,
        Ready,
        PickedUp,
        Cancelled

    }
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset PickupDate { get; set; } = DateTimeOffset.UtcNow;
        public decimal TotalAmount { get; set; }
        public status Status { get; set; } = status.Pending;
        public string? Note { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Created_At { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated_At { get; set; } = DateTimeOffset.UtcNow;
        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
        public virtual Payments? Payments { get; set; }
    }
}
