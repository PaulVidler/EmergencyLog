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

namespace EmergencyLog.Application.SmokeAlarms
{
    public class Details
    {
        public class Query : IRequest<Result<SmokeAlarm>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<SmokeAlarm>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<SmokeAlarm>> Handle(Query request, CancellationToken cancellationToken)
            {
                var smokeAlarm = await _context.SmokeAlarms.FindAsync(request.Id);
                return Result<SmokeAlarm>.Success(smokeAlarm);
            }
        }
    }
}
