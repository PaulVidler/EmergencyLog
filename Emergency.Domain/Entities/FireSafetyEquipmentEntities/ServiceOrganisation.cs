using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities
{
    public class ServiceOrganisation
    {
        public Guid ServiceOrganisationId { get; set; }
        public string ServiceOrganisationName { get; set; }
        public string Logo { get; set; } // url for logo upload
        public virtual Client PrimaryContact { get; set; }
        public Guid PrimaryContactId { get; set; }
        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
}
