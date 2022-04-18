#nullable enable
using System;
using System.Collections.Generic;

namespace EmergencyLog.Domain.Entities
{
    public class Client : Entity
    {
        public string? ImageSmall { get; set; }
        public string? ImageLarge { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public override Address Address { get; set; }
        public Guid AddressId { get; set; }
        public virtual EmergencyContact? EmergencyContact { get; set; }
        public Guid EmergencyContactId { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
        //public virtual Organisation? Organisation { get; set; }
    }
}
