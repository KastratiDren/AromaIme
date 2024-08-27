using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class OrderDTO
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string StripePaymentIntentId { get; set; } = string.Empty;

        [Required]
        public string SessionId { get; set; } = string.Empty;

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalAmount { get; set; }
    }
}
