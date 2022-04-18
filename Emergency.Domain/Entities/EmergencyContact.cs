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

        // navigation property for entity this emergency contact is related to
        // Darrens wife is his emergency contact, so Darrens entity id is put into this field
        public Guid RelationshipEntityId { get; set; }
        public override Address Address { get; set; }
    }
}
