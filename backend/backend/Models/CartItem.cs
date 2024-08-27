using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; } = null!;

        public int FragranceId { get; set; }
        [ForeignKey("FragranceId")]
        public Fragrance Fragrance { get; set; } = null!;

        [Required]
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10.")]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [NotMapped] 
        public decimal TotalAmount => Quantity * Price;
    }
}
