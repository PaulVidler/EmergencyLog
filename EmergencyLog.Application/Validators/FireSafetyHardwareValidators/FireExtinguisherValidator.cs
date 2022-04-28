using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using FluentValidation;

namespace EmergencyLog.Application.Validators.FireSafetyHardwareValidators
{
    internal class FireExtinguisherValidator : AbstractValidator<FireExtinguisher>
    {
        public FireExtinguisherValidator()
        {
            RuleFor(x => x.EquipmentType).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(256);
            RuleFor(x => x.LastServiced).NotEmpty();
            RuleFor(x => x.NextService).NotEmpty();
            RuleFor(x => x.ServicedOrganisationId).NotEmpty();
            RuleFor(x => x.PropertyId).NotEmpty();

        }
    }
}
