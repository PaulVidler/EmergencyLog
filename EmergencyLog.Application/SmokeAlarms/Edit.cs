using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators.FireSafetyHardwareValidators;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class EditCommandValidator : AbstractValidator<EditCommand<SmokeAlarm>>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new SmokeAlarmValidator());
        }
    }

    public class EditHandler : IRequestHandler<EditCommand<SmokeAlarm>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<SmokeAlarm> request, CancellationToken cancellationToken)
        {

            var smokeAlarm = await _context.SmokeAlarms.FindAsync(request.Type.Id);

            if (smokeAlarm == null) return null;

            _mapper.Map(request.Type, smokeAlarm);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update SmokeAlarm");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
