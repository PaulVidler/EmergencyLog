using System;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities
{
    public class Address : IAddress
    {
        public Guid Id { get; set; }
        //public Guid EntityId { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        // public virtual Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        // test change to see if reflected in Azure repo
    }
}
