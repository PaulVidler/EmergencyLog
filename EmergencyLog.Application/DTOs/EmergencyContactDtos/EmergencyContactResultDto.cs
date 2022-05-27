using System;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.DTOs.EmergencyContactDtos
{
    public class EmergencyContactResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Mobile { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public int ClientId { get; set; }
    }
}
