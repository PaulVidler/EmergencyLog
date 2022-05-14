using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class ListHandler : IRequestHandler<ListQuery<FireExtinguisher>, Result<PagedList<FireExtinguisher>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<FireExtinguisher>>> Handle(ListQuery<FireExtinguisher> request, CancellationToken cancellationToken)
        {
            var query = _context.FireExtinguishers.OrderBy(d => d.LastServiced).AsQueryable();

            return Result<PagedList<FireExtinguisher>>.Success(
                await PagedList<FireExtinguisher>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
