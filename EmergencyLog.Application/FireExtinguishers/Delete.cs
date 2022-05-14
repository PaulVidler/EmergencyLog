using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<FireExtinguisher>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<FireExtinguisher> request, CancellationToken cancellationToken)
        {
            var fireExtinguisher = await _context.FireExtinguishers.FindAsync(request.Id);
            if (fireExtinguisher == null) return null;

            _context.Remove(fireExtinguisher);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete FireExtinguisher");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
