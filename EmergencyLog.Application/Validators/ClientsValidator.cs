using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using FluentValidation;

namespace EmergencyLog.Application.Validators
{
    internal class ClientsValidator : AbstractValidator<Client>
    {
        public ClientsValidator()
        {
            RuleFor(x => x.ImageLarge).NotEmpty().MaximumLength(256);
            RuleFor(x => x.ImageSmall).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Role).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(256);
        }
    }
}
