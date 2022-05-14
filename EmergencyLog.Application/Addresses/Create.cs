using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Addresses
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<Address>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new AddressValidator());
        }
    }

    public class CreateHandler : IRequestHandler<CreateCommand<Address>, Result<Unit>>
    {
        private DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Address> request, CancellationToken cancellationToken)
        {

            _context.Addresses.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Address");

            return Result<Unit>.Success(Unit.Value);

        }
    }

}
