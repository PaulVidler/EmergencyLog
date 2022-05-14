using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Clients
{
    public class ListHandler : IRequestHandler<ListQuery<Client>, Result<PagedList<Client>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<Client>>> Handle(ListQuery<Client> request, CancellationToken cancellationToken)
        {
            var query = _context.Clients.OrderBy(d => d.Surname).AsQueryable();

            return Result<PagedList<Client>>.Success(
                await PagedList<Client>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
