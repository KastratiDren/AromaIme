using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class SeasonDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Season must be between 5 and 50 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
