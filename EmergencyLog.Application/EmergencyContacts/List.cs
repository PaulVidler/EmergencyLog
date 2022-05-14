using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class ListHandler : IRequestHandler<ListQuery<EmergencyContact>, Result<PagedList<EmergencyContact>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<EmergencyContact>>> Handle(ListQuery<EmergencyContact> request, CancellationToken cancellationToken)
        {
            var query = _context.EmergencyContacts.OrderBy(d => d.Surname).AsQueryable();

            return Result<PagedList<EmergencyContact>>.Success(
                await PagedList<EmergencyContact>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
