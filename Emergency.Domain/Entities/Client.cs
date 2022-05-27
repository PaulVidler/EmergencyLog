#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyLog.Domain.Entities
{
    public class Client : Entity
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
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
        public virtual EmergencyContact EmergencyContact { get; set; }
        public virtual Organisation Organisation { get; set; }
        public int OrganisationId { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
