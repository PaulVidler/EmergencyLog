using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain
{
    public class Attendance
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public IEntity Entity { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
    }
}
