#nullable enable
using System;
using System.Collections.Generic;

namespace EmergencyLog.Domain.Entities
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

    public class Client : Entity
    {
        
        public Guid Id { get; set; }
        public string? ImageSmall { get; set; }
        public string? ImageLarge { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public EmergencyContact? EmergencyContact { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
    }
}
