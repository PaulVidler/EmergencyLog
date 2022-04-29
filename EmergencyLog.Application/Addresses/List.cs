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

namespace EmergencyLog.Application.Addresses
{
    public class List
    {
        public class Query : IRequest<Result<List<Address>>> { }
        public class Handler : IRequestHandler<Query, Result<List<Address>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Address>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Address>>.Success(await _context.Addresses.ToListAsync());
            }
        }

    }
}
