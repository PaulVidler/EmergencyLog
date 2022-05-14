using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class ListHandler : IRequestHandler<ListQuery<SmokeAlarm>, Result<PagedList<SmokeAlarm>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<SmokeAlarm>>> Handle(ListQuery<SmokeAlarm> request, CancellationToken cancellationToken)
        {
            var query = _context.SmokeAlarms.OrderBy(d => d.LastServiced).AsQueryable();

            return Result<PagedList<SmokeAlarm>>.Success(
                await PagedList<SmokeAlarm>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
