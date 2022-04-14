using AutoMapper;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.FireHoses
{
    public class Edit
    {
        public class Command : IRequest
        {
            public FireHose FireHose { get; set; }
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
                var fireHose = await _context.FireHoses.FindAsync(request.FireHose.Id);
                
                _mapper.Map(request.FireHose, fireHose);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
