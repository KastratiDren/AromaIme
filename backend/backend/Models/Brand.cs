using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand name must be between 3 and 50 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
