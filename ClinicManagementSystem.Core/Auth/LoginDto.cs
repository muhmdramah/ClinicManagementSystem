using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Core.Auth
{
    public class LoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}