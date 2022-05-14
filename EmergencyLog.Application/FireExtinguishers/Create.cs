using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators.FireSafetyHardwareValidators;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<FireExtinguisher>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new FireExtinguisherValidator());
        }
    }


    public class CreateHandler : IRequestHandler<CreateCommand<FireExtinguisher>, Result<Unit>>
    {
        private DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<FireExtinguisher> request, CancellationToken cancellationToken)
        {

            _context.FireExtinguishers.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Fire Extinguisher");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
