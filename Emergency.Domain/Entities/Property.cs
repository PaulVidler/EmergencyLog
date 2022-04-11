using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain.Entities
{
    public class Property
    {
        public virtual Address Address { get; set; }
        public ICollection<SmokeAlarm> SmokeAlarmsCollection { get; set; }
        public virtual Client PrimaryContact { get; set; }
        public virtual Client? SecondaryContact { get; set; }
    }


}
