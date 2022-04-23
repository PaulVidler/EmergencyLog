using AutoMapper;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class Edit
    {
        public class Command : IRequest
        {
            public SmokeAlarm SmokeAlarm { get; set; }
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
                var smokeAlarm = await _context.SmokeAlarms.FindAsync(request.SmokeAlarm.Id);
                
                _mapper.Map(request.SmokeAlarm, smokeAlarm);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
