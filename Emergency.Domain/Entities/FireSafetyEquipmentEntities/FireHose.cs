using System;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

public class FireHose : Entity, IFireSafetyEquipment
{
    public string EquipmentType { get; set; }
    public string Description { get; set; }
    public DateTime? LastServiced { get; set; }
    public DateTime NextService { get; set; }
    public ServiceOrganisation ServiceOrganisation { get; set; }
    public int ServiceOrganisationId { get; set; }
    public Property Property { get; set; }
    public int PropertyId { get; set; }
}