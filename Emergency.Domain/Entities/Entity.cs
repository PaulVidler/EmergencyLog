using System;
using EmergencyLog.Domain.Entities.Interfaces;

namespace EmergencyLog.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            IsDeleted = false;
        }

        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int Id { get; set; }
        
    }
}
