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
    public class CreateCommandValidator : AbstractValidator<CreateCommand<SmokeAlarm>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new SmokeAlarmValidator());
        }
    }


    public class CreateHandler : IRequestHandler<CreateCommand<SmokeAlarm>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public CreateHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<SmokeAlarm> request, CancellationToken cancellationToken)
        {

            _context.SmokeAlarms.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Smoke Alarm");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
