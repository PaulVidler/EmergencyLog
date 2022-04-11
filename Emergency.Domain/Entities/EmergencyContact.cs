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

    public interface IEmergencyContact
    {
        public Client Client { get; set; }
        RelationshipType RelationshipType { get; set; }
    }

    public class EmergencyContact: Entity
    {
        public RelationshipType RelationshipType { get; set; }

        // navigation property
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
