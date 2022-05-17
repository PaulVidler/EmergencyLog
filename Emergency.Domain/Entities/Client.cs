#nullable enable
using System;
using System.Collections.Generic;

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
        public int? EmergencyContactId { get; set; }
        public Organisation Organisation { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
