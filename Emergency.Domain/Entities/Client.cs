#nullable enable
using System;
using System.Collections.Generic;

namespace EmergencyLog.Domain.Entities
{
    public class Client : Entity
    {
        
        public Guid Id { get; set; }
        public string? ImageSmall { get; set; }
        public string? ImageLarge { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public EmergencyContact? EmergencyContact { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
        //public virtual Organisation? Organisation { get; set; }
    }
}
