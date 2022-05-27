using System;
using System.Collections.Generic;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Domain.Entities
{
    public class Property : Entity
    {
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public virtual Organisation Organisation { get; set; }
        public int OrganisationId { get; set; }

        public ICollection<SmokeAlarm> SmokeAlarms { get; set; }
        public ICollection<FireExtinguisher> FireExtinguishers { get; set; }
        public ICollection<FireHose> FireHoses { get; set; }
    }
}
