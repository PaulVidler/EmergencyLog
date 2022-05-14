using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Clients
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<Client>, Result<Client>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Client>> Handle(DetailsQuery<Client> request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FindAsync(request.Id);
            return Result<Client>.Success(client);
        }
    }
}
