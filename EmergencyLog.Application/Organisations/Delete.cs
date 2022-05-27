using System;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.Organisations
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<Organisation>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<Organisation> request, CancellationToken cancellationToken)
        {
            var organisation = await _context.Organisations.FindAsync(request.Id);
            if (organisation == null) return null;

            organisation.IsDeleted = true;
            organisation.DateDeleted = DateTime.Now;

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete Organisation");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
