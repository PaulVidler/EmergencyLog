using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Organisations
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<Organisation>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new OrganisationValidator());
        }
    }


    public class CreateHandler : IRequestHandler<CreateCommand<Organisation>, Result<Unit>>
    {
        private DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Organisation> request, CancellationToken cancellationToken)
        {

            _context.Organisations.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Organisation");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
