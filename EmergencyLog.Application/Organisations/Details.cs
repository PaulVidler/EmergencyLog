using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Organisations
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<Organisation>, Result<Organisation>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Organisation>> Handle(DetailsQuery<Organisation> request, CancellationToken cancellationToken)
        {
            var organisation = await _context.Organisations.FindAsync(request.Id);
            return Result<Organisation>.Success(organisation);
        }
    }
}
