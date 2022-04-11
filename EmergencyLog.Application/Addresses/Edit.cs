using AutoMapper;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Addresses
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Domain.Address Address { get; set; }
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
                var address = await _context.Addresses.FindAsync(request.Address.Id);

                // this line below has been replaced by automapper line _mapper.Map.....
                // Address.Title = request.Address.Title ?? Address.Title; // if this is null, then just set it existing title

                // this line below, replaces the line above as a better means of mapping without having to check each property.
                _mapper.Map(request.Address, address);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
