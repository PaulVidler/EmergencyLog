using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Clients
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<Client>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new ClientsValidator());
        }
    }

    public class CreateHandler : IRequestHandler<CreateCommand<Client>, Result<Unit>>
    {
        private DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Client> request, CancellationToken cancellationToken)
        {
            _context.Clients.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Client");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
