#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain.Entities
{
    public class Organisation
    {
        public Guid Id { get; set; }
        public string OrganisationName { get; set; }
        public string Logo { get; set; } // url for logo upload
        public ICollection<Client> Clients { get; set; }
        public virtual Client PrimaryContact { get; set; }
        public virtual Client? SecondaryContact { get; set; }
        public virtual Address Address { get; set; }
    }
}
