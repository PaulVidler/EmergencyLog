using System;

namespace EmergencyLog.Domain.Entities.Interfaces;

public interface IAddress
{
    public Guid Id { get; set; }
    string StreetNumber { get; set; }
    string Street { get; set; }
    string Suburb { get; set; }
    string Postcode { get; set; }
    string Country { get; set; }
    //public Guid ClientId { get; set; }
    public Client Client { get; set; }
}