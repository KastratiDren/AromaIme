using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CartDTO
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        // List of cart items to be displayed in the cart page
        public List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalAmount { get; set; }
    }
}
