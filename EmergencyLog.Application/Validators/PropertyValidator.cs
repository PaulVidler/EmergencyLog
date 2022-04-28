using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EmergencyLog.Application.Validators
{
    public class PropertyValidator : AbstractValidator<Domain.Entities.Property>
    {
        public PropertyValidator()
        {
            //public Guid Id { get; set; }
            //public virtual Address Address { get; set; }
            //public Guid AddressId { get; set; }
            //public ICollection<SmokeAlarm> SmokeAlarms { get; set; } = null!;
            //public ICollection<FireExtinguisher> FireExtinguishers { get; set; } = null!;
            //public ICollection<FireHose> FireHoses { get; set; } = null!;
            //public virtual Client PrimaryContact { get; set; }
            //public virtual Organisation Organisation { get; set; }

            // should be some more properties here, entity framework fuckery with foreign keys
            RuleFor(x => x.AddressId).NotEmpty();

        }
    }
}
