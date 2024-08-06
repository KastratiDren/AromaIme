using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class BrandDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand name must be between 3 and 50 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
