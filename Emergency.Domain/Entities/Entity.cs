using System;

namespace EmergencyLog.Domain.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        //nav props
        public Address Address { get; set; }
        // public Guid AddressId { get; set; }
    }

    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        // navigation props
        public virtual Address Address { get; set; }
    }
}
