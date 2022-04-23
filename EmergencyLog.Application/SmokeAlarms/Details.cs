using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class Details
    {
        public class Query : IRequest<SmokeAlarm>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, SmokeAlarm>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<SmokeAlarm> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.SmokeAlarms.FindAsync(request.Id);
            }
        }
    }
}
