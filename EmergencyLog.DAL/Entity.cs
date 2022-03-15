using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.DAL
{
    public interface IEntity
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        DateTime DateOfBirth { get; set; }
        string Email { get; set; }
        Address Address { get; set; }
        string Phone { get; set; }
        string Mobile { get; set; }
    }

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
