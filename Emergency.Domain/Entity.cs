using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain
{
    public interface IEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
