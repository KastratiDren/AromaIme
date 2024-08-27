using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalAmount { get; set; }
    }
}
