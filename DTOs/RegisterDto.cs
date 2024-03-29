using System.ComponentModel.DataAnnotations;

namespace JobFairAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName {get; set;}

        [Required]
        public string Password { get; set; }

    }
}