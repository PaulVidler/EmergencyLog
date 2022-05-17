#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities
{
    public class Organisation : Entity
    {
        public string OrganisationName { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string? Logo { get; set; } // url for logo upload
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
