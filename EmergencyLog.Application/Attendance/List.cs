using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Attendance
{
    public class ListHandler : IRequestHandler<ListQuery<Domain.Entities.Attendance>, Result<PagedList<Domain.Entities.Attendance>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<Domain.Entities.Attendance>>> Handle(ListQuery<Domain.Entities.Attendance> request, CancellationToken cancellationToken)
        {
            var query = _context.Attendances.OrderBy(d => d.TimeOut).AsQueryable();

            return Result<PagedList<Domain.Entities.Attendance>>.Success(
                await PagedList<Domain.Entities.Attendance>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
