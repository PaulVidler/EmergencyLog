using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.FireHoses
{
    public class Details
    {
        public class Query : IRequest<Result<FireHose>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<FireHose>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<FireHose>> Handle(Query request, CancellationToken cancellationToken)
            {
                var fireHose = await _context.FireHoses.FindAsync(request.Id);
                return Result<FireHose>.Success(fireHose);
            }
        }
    }
}
