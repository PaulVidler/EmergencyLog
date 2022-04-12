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

        // navigation property
        public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
