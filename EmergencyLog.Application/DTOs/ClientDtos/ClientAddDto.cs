using System;

namespace EmergencyLog.Application.DTOs.ClientDtos
{
    public class ClientAddDto
    {
        public int OrganisationId { get; set; }
        public int EmergencyContactId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Mobile { get; set; }
        public string? ImageSmall { get; set; }
        public string? ImageLarge { get; set; }
        public string? Role { get; set; }
        public string? StreetNumber { get; set; }
        public string? Street { get; set; }
        public string? Suburb { get; set; }
        public string? Postcode { get; set; }
        public string? Country { get; set; }
    }
}
