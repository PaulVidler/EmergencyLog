using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.Clients
    public class List
    {
        public class Query : IRequest<List<Client>> { }
        public class Handler : IRequestHandler<Query, List<Client>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Client>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Clients.ToListAsync();
            }
        }

    }
}
