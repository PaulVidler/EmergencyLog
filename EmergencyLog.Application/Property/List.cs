using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Property
{
    public class ListHandler : IRequestHandler<ListQuery<Domain.Entities.Property>, Result<PagedList<Domain.Entities.Property>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<Domain.Entities.Property>>> Handle(ListQuery<Domain.Entities.Property> request, CancellationToken cancellationToken)
        {
            var query = _context.Properties.OrderBy(d => d.Country).AsQueryable();

            return Result<PagedList<Domain.Entities.Property>>.Success(
                await PagedList<Domain.Entities.Property>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
