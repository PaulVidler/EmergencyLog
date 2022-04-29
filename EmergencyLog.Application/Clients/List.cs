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
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.Clients
{
    public class List
    {
        public class Query : IRequest<Result<List<Client>>> { }
        public class Handler : IRequestHandler<Query, Result<List<Client>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Client>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Client>>.Success(await _context.Clients.ToListAsync());
            }
        }

    }
}
