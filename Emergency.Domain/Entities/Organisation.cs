#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain.Entities
{
    public class Organisation
    {
        public Guid OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string? Logo { get; set; } // url for logo upload
        public ICollection<Client> Clients { get; set; }
        public virtual Address? Address { get; set; }//
        public Guid AddressId { get; set; }
        public ICollection<Property>? Properties { get; set; } //
    }
}
