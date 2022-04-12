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

                // this line below has been replaced by automapper line _mapper.Map.....
                // EmergencyContact.Title = request.EmergencyContact.Title ?? EmergencyContact.Title; // if this is null, then just set it existing title

                // this line below, replaces the line above as a better means of mapping without having to check each property.
                _mapper.Map(request.FireHose, fireHose);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
