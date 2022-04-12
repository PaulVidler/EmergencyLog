using AutoMapper;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Application.Organisations
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Organisation Organisation { get; set; }
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
                var organisation = await _context.Organisations.FindAsync(request.Organisation.Id);
                _mapper.Map(request.Organisation, organisation);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
