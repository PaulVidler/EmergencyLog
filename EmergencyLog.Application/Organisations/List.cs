using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Organisations
{
    public class ListHandler : IRequestHandler<ListQuery<Organisation>, Result<PagedList<Organisation>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<Organisation>>> Handle(ListQuery<Organisation> request, CancellationToken cancellationToken)
        {
            var query = _context.Organisations.OrderBy(d => d.OrganisationName).AsQueryable();

            return Result<PagedList<Organisation>>.Success(
                await PagedList<Organisation>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
