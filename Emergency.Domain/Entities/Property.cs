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
        public virtual ICollection<SmokeAlarm> SmokeAlarmsCollection { get; set; } = null!;
        public virtual ICollection<FireExtinguisher> FireExtinguishers { get; set; } = null!;
        public virtual ICollection<FireHose> FireHoses { get; set; } = null!;
        public virtual Client PrimaryContact { get; set; }
        public Guid PrimaryContactId { get; set; }
    }
}
