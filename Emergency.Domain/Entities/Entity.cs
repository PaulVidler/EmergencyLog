using System;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        // navigation props
        public abstract Address Address { get; set;  }
        public Guid AddressId { get; set; }
    }
}
