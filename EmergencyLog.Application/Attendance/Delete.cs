using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Attendance
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<Domain.Entities.Attendance>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<Domain.Entities.Attendance> request, CancellationToken cancellationToken)
        {
            var attendance = await _context.Attendances.FindAsync(request.Id);
            if (attendance == null) return null;

            _context.Remove(attendance);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete Attendance");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
