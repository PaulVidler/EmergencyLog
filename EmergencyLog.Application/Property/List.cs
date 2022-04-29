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

namespace EmergencyLog.Application.Property
{
    public class List
    {
        public class Query : IRequest<Result<List<Domain.Entities.Property>>> { }
        public class Handler : IRequestHandler<Query, Result<List<Domain.Entities.Property>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Domain.Entities.Property>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Domain.Entities.Property>>.Success(await _context.Properties.ToListAsync());
            }
        }

    }
}
