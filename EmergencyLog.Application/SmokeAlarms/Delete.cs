using System;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<SmokeAlarm>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<SmokeAlarm> request, CancellationToken cancellationToken)
        {
            var smokeAlarm = await _context.SmokeAlarms.FindAsync(request.Id);
            if (smokeAlarm == null) return null;

            smokeAlarm.IsDeleted = true;
            smokeAlarm.DateDeleted = DateTime.Now;

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete SmokeAlarm");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
