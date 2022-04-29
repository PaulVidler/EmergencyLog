using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class List
    {
        public class Query : IRequest<Result<List<SmokeAlarm>>> { }
        public class Handler : IRequestHandler<Query, Result<List<SmokeAlarm>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SmokeAlarm>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<SmokeAlarm>>.Success(await _context.SmokeAlarms.ToListAsync());
            }
        }

    }
}
