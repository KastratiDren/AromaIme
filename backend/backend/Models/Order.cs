using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;


        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty ;
        [Required]
        public string Address { get; set; }= string.Empty ;

        [Required]
        public string StripePaymentIntentId { get; set; } = string.Empty;
        [Required]
        public string SessionId { get; set; } = string.Empty;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalAmount { get; set; }
    }
}
