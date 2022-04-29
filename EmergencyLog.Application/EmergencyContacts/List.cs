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

namespace EmergencyLog.Application.EmergencyContacts
{
    public class List
    {
        public class Query : IRequest<Result<List<EmergencyContact>>> { }
        public class Handler : IRequestHandler<Query, Result<List<EmergencyContact>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<EmergencyContact>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<EmergencyContact>>.Success(await _context.EmergencyContacts.ToListAsync());
            }
        }

    }
}
