using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities
{
    public class ServiceOrganisation : Entity
    {
        public string ServiceOrganisationName { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string? Logo { get; set; } // url for logo upload
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public ICollection<FireHose> FireHoses { get; set; }
        public ICollection<FireExtinguisher> FireExtinguishers { get; set; }
        public ICollection<SmokeAlarm> SmokeAlarms { get; set; }
    }
}
