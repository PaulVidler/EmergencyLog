using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Attendance
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Domain.Attendance Attendance { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext _context;
            private IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var attendance = await _context.Attendances.FindAsync(request.Attendance.Id);

                // this line below has been replaced by automapper line _mapper.Map.....
                // Attendance.Title = request.Attendance.Title ?? Attendance.Title; // if this is null, then just set it existing title

                // this line below, replaces the line above as a better means of mapping without having to check each property.
                _mapper.Map(request.Attendance, attendance);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
