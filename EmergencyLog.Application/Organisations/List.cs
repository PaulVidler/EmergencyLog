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

namespace EmergencyLog.Application.Organisations
{
    public class List
    {
        public class Query : IRequest<Result<List<Organisation>>> { }
        public class Handler : IRequestHandler<Query, Result<List<Organisation>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Organisation>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Organisation>>.Success(await _context.Organisations.ToListAsync());
            }
        }

    }
}
