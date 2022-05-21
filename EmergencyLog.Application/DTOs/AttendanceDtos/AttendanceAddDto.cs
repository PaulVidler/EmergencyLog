using System;

namespace EmergencyLog.Application.DTOs.AttendanceDtos
{
    public class AttendanceAddDto
    {
        public DateTime TimeIn { get; set; }
        public bool OnSite { get; set; } = true;
        public bool EntryComplete { get; set; } = false;
        public int ClientId { get; set; }
    }
}
