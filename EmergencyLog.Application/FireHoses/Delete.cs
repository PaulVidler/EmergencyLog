using System;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Application.FireHoses
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<FireHose>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<FireHose> request, CancellationToken cancellationToken)
        {
            var fireHose = await _context.FireHoses.FindAsync(request.Id);
            if (fireHose == null) return null;

            fireHose.IsDeleted = true;
            fireHose.DateDeleted = DateTime.Now;

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete FireHose");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
