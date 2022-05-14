using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Addresses
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<Address>, Result<Address>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Address>> Handle(DetailsQuery<Address> request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses.FindAsync(request.Id);
            return Result<Address>.Success(address);
        }
    }
}
