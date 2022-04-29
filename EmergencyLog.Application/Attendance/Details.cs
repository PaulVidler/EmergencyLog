using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Attendance
{
    public class Details
    {
        public class Query : IRequest<Result<Domain.Entities.Attendance>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<Domain.Entities.Attendance>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Domain.Entities.Attendance>> Handle(Query request, CancellationToken cancellationToken)
            {
                var attendance = await _context.Attendances.FindAsync(request.Id);
                return Result<Domain.Entities.Attendance>.Success(attendance);
            }
        }
    }
}
