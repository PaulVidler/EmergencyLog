using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Property
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<Domain.Entities.Property>, Result<Domain.Entities.Property>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Domain.Entities.Property>> Handle(DetailsQuery<Domain.Entities.Property> request, CancellationToken cancellationToken)
        {
            var property = await _context.Properties.FindAsync(request.Id);
            return Result<Domain.Entities.Property>.Success(property);
        }
    }
}
