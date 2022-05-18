using System;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.Attendance
{
    public class AttendanceDto
    {
        public Guid GlobalId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
        public int ClientId { get; set; }
    }
}
