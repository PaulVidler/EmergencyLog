using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<EmergencyContact>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new EmergencyContactValidator());
        }
    }
    
    public class CreateHandler : IRequestHandler<CreateCommand<EmergencyContact>, Result<Unit>>
    {
        private DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<EmergencyContact> request, CancellationToken cancellationToken)
        {

            _context.EmergencyContacts.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Emergency Contact");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
