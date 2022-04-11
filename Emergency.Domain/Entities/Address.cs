using System;

namespace EmergencyLog.Domain.Entities
{

    public interface IAddress
    {
        public Guid Id { get; set; }
        string StreetNumber { get; set; }
        string Street { get; set; }
        string Suburb { get; set; }
        string Postcode { get; set; }
        string Country { get; set; }
        public Guid EntityId { get; set; }
    }

    public class Address : IAddress
    {
        public Guid Id { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public Guid EntityId { get; set; }

    }
}
