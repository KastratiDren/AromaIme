using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 30 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
