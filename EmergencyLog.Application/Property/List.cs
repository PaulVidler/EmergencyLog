using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.Property
{
    public class List
    {
        public class Query : IRequest<List<Domain.Entities.Property>> { }
        public class Handler : IRequestHandler<Query, List<Domain.Entities.Property>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.Entities.Property>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Properties.ToListAsync();
            }
        }

    }
}
