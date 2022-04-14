using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Attendance
{
    public class Create
    {
        public class Command : IRequest
        {
            public Domain.Entities.Attendance Attendance { get; set; }
        }

        public class Handler : IRequestHandler<Attendance.Create.Command>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Attendance.Create.Command request, CancellationToken cancellationToken)
            {
                _context.Attendances.Add(request.Attendance);
                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
