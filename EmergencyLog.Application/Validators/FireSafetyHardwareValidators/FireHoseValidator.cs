using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using FluentValidation;

namespace EmergencyLog.Application.Validators.FireSafetyHardwareValidators
{
    public class FireHoseValidator : AbstractValidator<FireHose>
    {
        public FireHoseValidator()
        {
            RuleFor(x => x.EquipmentType).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(256);
            RuleFor(x => x.LastServiced).NotEmpty();
            RuleFor(x => x.NextService).NotEmpty();

        }
    }
}
