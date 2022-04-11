using System;

namespace EmergencyLog.Domain.Entities
{
    public interface IAttendance
    {
        Guid Id { get; set; }
        DateTime TimeIn { get; set; }
        DateTime? TimeOut { get; set; }
        bool OnSite { get; set; }
        bool EntryComplete { get; set; }
        Client Client { get; set; }
    }

    public class Attendance : IAttendance
    {
        public Guid Id { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
        public virtual Client Client { get; set; }
    }
}
