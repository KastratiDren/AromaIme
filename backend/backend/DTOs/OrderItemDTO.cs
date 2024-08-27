using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public int FragranceId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10.")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public decimal TotalAmount => Quantity * Price;
    }
}
