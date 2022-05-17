using System;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities
{
    public class SmokeAlarm : Entity,  IFireSafetyEquipment
    {
        public string EquipmentType { get; set; }
        public string Description { get; set; }
        public DateTime LastServiced { get; set; }
        public DateTime NextService { get; set; }
        public ServiceOrganisation ServiceOrganisation { get; set; }
        public Property Property { get; set; }
    }
}
