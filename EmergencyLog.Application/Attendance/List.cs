using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.Attendance
{
    public class List
    {
        public class Query : IRequest<PagedList<Domain.Entities.Attendance>> { }
        public class Handler : IRequestHandler<Query, PagedList<Domain.Entities.Attendance>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<PagedList<Domain.Entities.Attendance>> Handle(Query request, CancellationToken cancellationToken)
            {
                var attendance =  await _context.Attendances.ToListAsync();

                return Result<PagedList<Domain.Entities.Attendance>>.Success(attendance);
            }
        }

    }
}
