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

namespace EmergencyLog.Application.EmergencyContacts
{
    public class List
    {
        public class Query : IRequest<List<EmergencyContact>> { }
        public class Handler : IRequestHandler<Query, List<EmergencyContact>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<EmergencyContact>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.EmergencyContacts.ToListAsync();
            }
        }

    }
}
