using System;

namespace EmergencyLog.Application.DTOs.PropertyDtos
{
    public class PropertyEditDto
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public int OrganisationId { get; set; }
    }
}
