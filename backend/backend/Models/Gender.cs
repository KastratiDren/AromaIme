using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Gender must be between 3 and 15 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
