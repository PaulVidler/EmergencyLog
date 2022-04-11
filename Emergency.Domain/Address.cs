using System;

namespace EmergencyLog.Domain
{

    public interface IAddress
    {
        public Guid Id { get; set; }
        string StreetNumber { get; set; }
        string Street { get; set; }
        string Suburb { get; set; }
        string Postcode { get; set; }
        string Country { get; set; }
    }

    public class Address : IAddress
    {
        //[Key]
        public Guid Id { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        // navigation property
        public virtual Entity Entity { get; set; }
        public Guid EntityId { get; set; }

    }
}
