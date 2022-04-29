using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using FluentValidation;

namespace EmergencyLog.Application.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Country).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Street).NotEmpty().MaximumLength(256);
            RuleFor(x => x.StreetNumber).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Suburb).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Postcode).NotEmpty().MaximumLength(25);

        }
    }
}
