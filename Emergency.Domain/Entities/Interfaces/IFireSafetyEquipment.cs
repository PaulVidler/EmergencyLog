using System;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Domain.Entities.Interfaces;

public interface IFireSafetyEquipment
{
    string EquipmentType { get; set; }
    string Description { get; set; }
    DateTime? LastServiced { get; set; }
    DateTime NextService { get; set; }
    ServiceOrganisation? ServiceOrganisation { get; set; }
    Property Property { get; set; }
}