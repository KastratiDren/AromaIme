using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ScentDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Scent name must be between 10 and 30 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
