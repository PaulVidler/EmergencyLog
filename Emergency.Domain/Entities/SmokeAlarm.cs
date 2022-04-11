using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain.Entities
{
    public interface IFireSafetyEquipment
    {
        Guid Id { get; set; }
        string EquipmentType { get; set; }
        string Description { get; set; }
        DateTime LastServiced { get; set; }
        DateTime NextService { get; set; }
        Organisation ServicedBy { get; set; }
    }

    public class SmokeAlarm : IFireSafetyEquipment
    {
        public Guid Id { get; set; }
        public string EquipmentType { get; set; }
        public string Description { get; set; }
        public DateTime LastServiced { get; set; }
        public DateTime NextService { get; set; }
        public Organisation ServicedBy { get; set; }
    }
}
