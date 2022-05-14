using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<FireExtinguisher>, Result<FireExtinguisher>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<FireExtinguisher>> Handle(DetailsQuery<FireExtinguisher> request, CancellationToken cancellationToken)
        {
            var fireExtinguisher = await _context.FireExtinguishers.FindAsync(request.Id);
            return Result<FireExtinguisher>.Success(fireExtinguisher);
        }
    }
}
