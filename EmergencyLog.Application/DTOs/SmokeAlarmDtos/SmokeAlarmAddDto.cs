using System;

namespace EmergencyLog.Application.DTOs.SmokeAlarmDtos
{
    public class SmokeAlarmAddDto
    {
        public string EquipmentType { get; set; }
        public string Description { get; set; }
        public DateTime? LastServiced { get; set; }
        public DateTime NextService { get; set; }
        public int ServiceOrganisationId { get; set; }
        public int PropertyId { get; set; }
    }
}
