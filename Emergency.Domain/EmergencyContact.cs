using System;

namespace EmergencyLog.Domain
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
        //public Guid ClientId { get; set; }
        RelationshipType RelationshipType { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        DateTime? DateOfBirth { get; set; }
        string Email { get; set; }
        Address Address { get; set; }
        string Phone { get; set; }
        string Mobile { get; set; }
    }

    public class EmergencyContact: Entity, IEmergencyContact
    {
        public RelationshipType RelationshipType { get; set; }

        // navigation property
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
