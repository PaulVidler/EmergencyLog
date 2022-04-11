#nullable enable
using System;
using System.Collections.Generic;

namespace EmergencyLog.Domain
{
    public interface IClient
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        DateTime? DateOfBirth { get; set; }
        string Email { get; set; }
        string? ImageSmall { get; set; }
        string? ImageLarge { get; set; }
        string? Phone { get; set; }
        string Mobile { get; set; }
        EmergencyContact? EmergencyContact { get; set; }
        Address Address { get; set; }
        ICollection<Attendance>? Attendances { get; set; }
    }

    public class Client : Entity, IClient
    {
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string? ImageSmall { get; set; }
        public string? ImageLarge { get; set; }
        public string? Phone { get; set; }
        public string Mobile { get; set; }

        // navigation properties
        //public Entity Entity { get; set; }
        //public Guid EntityId { get; set; }
        public EmergencyContact? EmergencyContact { get; set; }
        //public Guid EmergencyContactId { get; set; }
        public virtual Address Address { get; set; }
        // public Guid AddressId { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
    }
}
