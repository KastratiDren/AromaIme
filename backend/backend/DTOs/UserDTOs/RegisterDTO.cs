using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.UserDTOs
{
    public class RegisterDTO
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        public string Surname { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
