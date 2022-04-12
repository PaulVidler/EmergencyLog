using System;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities;

public class FireHose : IFireSafetyEquipment
{
    public Guid Id { get; set; }
    public string EquipmentType { get; set; }
    public string Description { get; set; }
    public DateTime LastServiced { get; set; }
    public DateTime NextService { get; set; }
    public virtual Organisation ServicedBy { get; set; }
    public virtual Property Property { get; set; }
}