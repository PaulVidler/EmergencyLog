using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using FluentValidation;

namespace EmergencyLog.Application.Validators
{
    public class OrganisationValidator : AbstractValidator<Organisation>
    {
        public OrganisationValidator()
        {
            RuleFor(x => x.OrganisationName).NotEmpty().MaximumLength(256);
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(256);
            RuleFor(x => x.WebsiteUrl).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Logo).NotEmpty().MaximumLength(256);
            RuleFor(x => x.AddressId).NotEmpty();

        }
    }
}
