using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<EmergencyContact>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<EmergencyContact> request, CancellationToken cancellationToken)
        {
            var emergencyContact = await _context.EmergencyContacts.FindAsync(request.Id);
            if (emergencyContact == null) return null;

            _context.Remove(emergencyContact);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete EmergencyContact");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
