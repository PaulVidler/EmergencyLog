using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireHoses
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<FireHose>, Result<FireHose>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<FireHose>> Handle(DetailsQuery<FireHose> request, CancellationToken cancellationToken)
        {
            var fireHose = await _context.FireHoses.FindAsync(request.Id);
            return Result<FireHose>.Success(fireHose);
        }
    }
}
