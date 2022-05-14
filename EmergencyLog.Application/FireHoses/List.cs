using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireHoses
{
    public class ListHandler : IRequestHandler<ListQuery<FireHose>, Result<PagedList<FireHose>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<FireHose>>> Handle(ListQuery<FireHose> request, CancellationToken cancellationToken)
        {
            var query = _context.FireHoses.OrderBy(d => d.LastServiced).AsQueryable();

            return Result<PagedList<FireHose>>.Success(
                await PagedList<FireHose>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
