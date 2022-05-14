using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Property
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<Domain.Entities.Property>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new PropertyValidator());
        }
    }
    
    public class CreateHandler : IRequestHandler<CreateCommand<Domain.Entities.Property>, Result<Unit>>
    {
        private DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Domain.Entities.Property> request, CancellationToken cancellationToken)
        {

            _context.Properties.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Property");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
