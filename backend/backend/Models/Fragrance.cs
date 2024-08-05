using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Fragrance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 3 , ErrorMessage = "Name must be between 3 and 35 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500, MinimumLength = 300, ErrorMessage = "Description must be between 300 and 500 characters.")]
        public string Description { get; set; } =string.Empty;

        [Required]
        [Range(2.50, 1000.00, ErrorMessage = "Price must be between 2.50 and 1000.00.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
    }
}
