using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        //public int CartId { get; set; } 
        //[ForeignKey("CartId")]
        //public Cart Cart { get; set; } = null!;

        public int FragranceId { get; set; }
        [ForeignKey("FragranceId")]
        public Fragrance Fragrance { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
