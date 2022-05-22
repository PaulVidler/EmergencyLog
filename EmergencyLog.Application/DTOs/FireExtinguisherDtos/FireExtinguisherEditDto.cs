using System;

namespace EmergencyLog.Application.DTOs.FireExtinguisherDtos
{
    public class FireExtinguisherEditDto
    {
        public string EquipmentType { get; set; }
        public string Description { get; set; }
        public DateTime? LastServiced { get; set; }
        public DateTime NextService { get; set; }
        public int ServiceOrganisationId { get; set; }
        public int PropertyId { get; set; }
    }
}
