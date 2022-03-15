using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.DAL
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
        IEntity EntityRelationship { get; set; }
        RelationshipType RelationshipType { get; set; }
        int Id { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        DateTime DateOfBirth { get; set; }
        string Email { get; set; }
        Address Address { get; set; }
        string Phone { get; set; }
        string Mobile { get; set; }
    }

    public class EmergencyContact: Entity, IEmergencyContact
    {
        public IEntity EntityRelationship { get; set; }
        public RelationshipType RelationshipType { get; set; }
    }
}
