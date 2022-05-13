using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.Identity;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Addresses
{
    public class ListHandler : IRequestHandler<ListQuery<Address>, Result<PagedList<Address>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<Address>>> Handle(ListQuery<Address> request, CancellationToken cancellationToken)
        {
            var query = _context.Addresses.OrderBy(d => d.Country).AsQueryable();

            return Result<PagedList<Address>>.Success(
                await PagedList<Address>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
