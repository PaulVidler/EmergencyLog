using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators.FireSafetyHardwareValidators;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireHoses
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<FireHose>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new FireHoseValidator());
        }
    }
    
    public class CreateHandler : IRequestHandler<CreateCommand<FireHose>, Result<Unit>>
    {
        private DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<FireHose> request, CancellationToken cancellationToken)
        {

            _context.FireHoses.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Fire Hose");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
