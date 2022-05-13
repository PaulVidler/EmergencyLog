using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmergencyLog.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Organisation Organisation { get; set; }
        public Guid OrganisationId { get; set; }
        public Client? Client { get; set; }
        public Guid? ClientId { get; set; }
    }
}
