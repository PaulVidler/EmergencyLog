using System;
using System.Collections.Generic;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Domain.Entities
{
    public class Property
    {
        public Guid Id { get; set; }
        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }
        public ICollection<SmokeAlarm> SmokeAlarms { get; set; } = null!;
        public ICollection<FireExtinguisher> FireExtinguishers { get; set; } = null!;
        public ICollection<FireHose> FireHoses { get; set; } = null!;
        public virtual Client PrimaryContact { get; set; } 
        public virtual Organisation Organisation { get; set; } 
        //public virtual Guid OrganisationId { get; set; }

    }
}
