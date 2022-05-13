using System;
using System.ComponentModel.DataAnnotations;

namespace EmergencyLog.Api.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,10}$", 
            ErrorMessage = "Password must be between 4 - 10 characters and contain at least 1 number, 1 lower case character and 1 upper case character")] // Regex defines this error message
        public  string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public Guid OrganisationId { get; set; }
    }
}
