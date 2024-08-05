using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Season
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Season must be between 5 and 50 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
