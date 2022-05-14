using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.Addresses
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<Address>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<Address> request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses.FindAsync(request.Id);
            if (address == null) return null;

            _context.Remove(address);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete Address");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
