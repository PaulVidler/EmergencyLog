using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators.FireSafetyHardwareValidators;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public SmokeAlarm SmokeAlarm { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.SmokeAlarm).SetValidator(new SmokeAlarmValidator());
            }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private DataContext _context;
            private IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var smokeAlarm = await _context.FireExtinguishers.FindAsync(request.SmokeAlarm.Id);

                if (smokeAlarm == null) return null;
                _mapper.Map(request.SmokeAlarm, smokeAlarm);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create SmokeAlarm");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
