using System;

namespace EmergencyLog.Domain.Entities
{
    public enum RelationshipType
    {
        Mother,
        Sister,
        Father,
        Brother,
        Cousin,
        Grandparent,
        Friend,
        Partner,
        Other,

    }

    public class EmergencyContact: Entity
    {
        public RelationshipType RelationshipType { get; set; }
        public Client Client { get; set; } // whomever this emergency contact is related to
        public Guid ClientId { get; set; }
        public override Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
}
