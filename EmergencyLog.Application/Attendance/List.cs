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

namespace EmergencyLog.Application.Attendence
{
    public class List
    {
        public class Query : IRequest<List<Attendance>> { }
        public class Handler : IRequestHandler<Query, List<Attendance>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Attendance>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Attendances.ToListAsync();
            }
        }

    }
}
