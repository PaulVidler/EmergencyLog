using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class List
    {
        public class Query : IRequest<List<FireExtinguisher>> { }
        public class Handler : IRequestHandler<Query, List<FireExtinguisher>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<FireExtinguisher>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FireExtinguishers.ToListAsync();
            }
        }

    }
}
