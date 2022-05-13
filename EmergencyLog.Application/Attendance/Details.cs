using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Attendance
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<Domain.Entities.Attendance>, Result<Domain.Entities.Attendance>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Domain.Entities.Attendance>> Handle(DetailsQuery<Domain.Entities.Attendance> request, CancellationToken cancellationToken)
        {
            var attendance = await _context.Attendances.FindAsync(request.Id);
            return Result<Domain.Entities.Attendance>.Success(attendance);
        }
    }
}
