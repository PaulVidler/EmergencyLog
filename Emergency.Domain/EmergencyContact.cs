﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        int EntityRelationshipId { get; set; }
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
        
        public EmergencyContact()
        {
        }
        
        public int EntityRelationshipId { get; set; }
        public RelationshipType RelationshipType { get; set; }
    }
}
