using System;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities
{
    public class Attendance : IAttendance
    {
        public Guid Id { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
        // public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
