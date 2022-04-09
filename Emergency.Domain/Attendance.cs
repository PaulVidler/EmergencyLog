using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain
{
    public class Attendance
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public Guid EntityForeignKey { get; set; }
        [ForeignKey("EntityForeignKey")]
        public Entity Entity { get; set; }
        public bool OnSite { get; set; }
        public bool EntryComplete { get; set; }
    }
}
