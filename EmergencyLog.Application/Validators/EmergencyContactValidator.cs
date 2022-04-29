using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using FluentValidation;

namespace EmergencyLog.Application.Validators
{
    public class EmergencyContactValidator : AbstractValidator<EmergencyContact>
    {
        public EmergencyContactValidator()
        {

            // should be able to define enum in here, not sure what's up......
            // RuleFor(x => x.RelationshipType).NotEmpty().IsEnumName(typeof(RelationshipType));
            RuleFor(x => x.RelationshipType).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.AddressId).NotEmpty();

        }
    }
}
