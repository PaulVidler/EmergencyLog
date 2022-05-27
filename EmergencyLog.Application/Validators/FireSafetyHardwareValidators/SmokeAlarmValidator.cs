using System;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using FluentValidation;

namespace EmergencyLog.Application.Validators.FireSafetyHardwareValidators
{
    public class SmokeAlarmValidator : AbstractValidator<SmokeAlarm>
    {
        public SmokeAlarmValidator()
        {
            RuleFor(x => x.EquipmentType).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(256);
            RuleFor(x => x.LastServiced).NotEmpty();
            RuleFor(x => x.NextService).NotEmpty();

        }
    }
}
