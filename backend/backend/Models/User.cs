using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        public string Surname { get; set; } = string.Empty;

    }
}
