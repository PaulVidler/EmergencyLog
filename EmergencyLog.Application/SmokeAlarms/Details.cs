using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<SmokeAlarm>, Result<SmokeAlarm>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<SmokeAlarm>> Handle(DetailsQuery<SmokeAlarm> request, CancellationToken cancellationToken)
        {
            var smokeAlarm = await _context.SmokeAlarms.FindAsync(request.Id);
            return Result<SmokeAlarm>.Success(smokeAlarm);
        }
    }
}
