using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Fragrance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 3 , ErrorMessage = "Fragance name must be between 3 and 35 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500, MinimumLength = 300, ErrorMessage = "Fragrance description must be between 300 and 500 characters.")]
        public string Description { get; set; } =string.Empty;

        [Required]
        [Range(2.50, 1000.00, ErrorMessage = "Fragrance price must be between 2.50 and 1000.00.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 20, ErrorMessage = "Fragance notes must be between 20 and 75 characters.")]
        public string Notes { get; set; } = string.Empty;

        [Required]
        [Range(2, 200, ErrorMessage = "Fragrance size must be between 2 and 200.")]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Launch Date")]
        public DateOnly LaunchDate { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 75, ErrorMessage = "Fragance ingredients must be between 75 and 300 characters.")]
        public string Ingredients { get; set; } = string.Empty;

    }
}
