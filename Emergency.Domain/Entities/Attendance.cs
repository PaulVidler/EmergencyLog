using System;
using System.ComponentModel.DataAnnotations.Schema;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities
{
    public class Attendance : Entity, IAttendance
    {
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
