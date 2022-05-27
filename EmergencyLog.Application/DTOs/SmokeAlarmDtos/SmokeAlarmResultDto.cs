﻿using System;

namespace EmergencyLog.Application.DTOs.SmokeAlarmDtos
{
    public class SmokeAlarmResultDto
    {
        public int Id { get; set; }
        public string EquipmentType { get; set; }
        public string Description { get; set; }
        public DateTime? LastServiced { get; set; }
        public DateTime NextService { get; set; }
        public int ServiceOrganisationId { get; set; }
        public int PropertyId { get; set; }
    }
}
