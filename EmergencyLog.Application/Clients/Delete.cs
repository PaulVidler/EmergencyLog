using System;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.Clients
{
    public class DeleteHandler : IRequestHandler<DeleteCommand<Client>, Result<Unit>>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeleteCommand<Client> request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FindAsync(request.Id);
            if (client == null) return null;

            client.IsDeleted = true;
            client.DateDeleted = DateTime.Now;

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete client");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
