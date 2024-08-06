using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class LongevityDTO
    {
        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Longevity must be between 4 and 15 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
