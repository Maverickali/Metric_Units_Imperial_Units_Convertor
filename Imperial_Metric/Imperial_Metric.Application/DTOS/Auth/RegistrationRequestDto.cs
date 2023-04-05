using System.ComponentModel.DataAnnotations;

namespace Imperial_Metric.Application.DTOS.Auth
{
    public class RegistrationRequestDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
