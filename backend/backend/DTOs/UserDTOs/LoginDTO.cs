using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.UserDTOs
{
    public class LoginDTO
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
