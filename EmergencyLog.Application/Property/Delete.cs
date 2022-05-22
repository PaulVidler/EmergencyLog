using System;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Property
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<Domain.Entities.Property>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<Domain.Entities.Property> request, CancellationToken cancellationToken)
        {
            var property = await _context.Properties.FindAsync(request.Id);
            if (property == null) return null;

            property.IsDeleted = true;
            property.DateDeleted = DateTime.Now;

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete Property");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
