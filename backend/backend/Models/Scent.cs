using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Scent
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Scent name must be between 10 and 30 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
