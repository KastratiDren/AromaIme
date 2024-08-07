using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FragranceDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Fragance name must be between 1 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(1000, MinimumLength = 100, ErrorMessage = "Fragrance description must be between 300 and 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(2.50, 1000.00, ErrorMessage = "Fragrance price must be between 2.50 and 1000.00.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Fragance notes must be between 20 and 75 characters.")]
        public string Notes { get; set; } = string.Empty;

        [Required]
        [Range(2, 200, ErrorMessage = "Fragrance size must be between 2 and 200.")]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Launch Year")]
        [Range(1950, 2024, ErrorMessage = "Please enter a valid year.")]
        public int LaunchYear { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 35, ErrorMessage = "Fragance ingredients must be between 75 and 300 characters.")]
        public string Ingredients { get; set; } = string.Empty;

        // Foreign Keys
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public int LongevityId { get; set; }
        [Required]
        public int ScentId { get; set; }
        [Required]
        public int SeasonId { get; set; }
        [Required]
        public int SillageId { get; set; }
    }
}

