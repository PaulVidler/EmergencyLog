using System;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Domain.Entities.Interfaces;

public interface IFireSafetyEquipment
{
    Guid Id { get; set; }
    string EquipmentType { get; set; }
    string Description { get; set; }
    DateTime LastServiced { get; set; }
    DateTime NextService { get; set; }
    ServiceOrganisation ServicedOrganisation { get; set; }
}