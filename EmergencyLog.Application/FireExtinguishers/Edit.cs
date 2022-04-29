using AutoMapper;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators.FireSafetyHardwareValidators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using FluentValidation;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FireExtinguisher FireExtinguisher { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FireExtinguisher).SetValidator(new FireExtinguisherValidator());
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

                var fireExtinguisher = await _context.FireExtinguishers.FindAsync(request.FireExtinguisher.Id);

                if (fireExtinguisher == null) return null;

                _mapper.Map(request.FireExtinguisher, fireExtinguisher);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update FireExtinguisher");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
