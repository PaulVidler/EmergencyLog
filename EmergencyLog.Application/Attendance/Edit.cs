using AutoMapper;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Attendance
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Domain.Entities.Attendance Attendance { get; set; }
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
                
                _mapper.Map(request.Attendance, attendance);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
