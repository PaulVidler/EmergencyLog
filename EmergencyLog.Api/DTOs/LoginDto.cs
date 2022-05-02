using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Api.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
