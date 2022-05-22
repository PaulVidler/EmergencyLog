using System;

namespace EmergencyLog.Application.DTOs.OrganisationDtos
{
    public class OrganisationEditDto
    {
        public string OrganisationName { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string? Logo { get; set; } // url for logo upload
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
    }
}
