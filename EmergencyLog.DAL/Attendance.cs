using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.DAL
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public IEntity Entity { get; set; }
        public bool InOffice { get; set; }
        public bool LeftForDay { get; set; }
    }
}
