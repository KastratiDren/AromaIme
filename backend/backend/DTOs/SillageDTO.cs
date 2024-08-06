using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class SillageDTO
    {
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Sillage must be between 4 and 15 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
