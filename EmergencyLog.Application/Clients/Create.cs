using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Clients
{
    public class Create
    {
        public class Command : IRequest
        {
            public Client Client { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Clients.Add(request.Client);
                await _context.SaveChangesAsync();

                // This value is essentially a void or null value, which allows the API to know
                // we are finished whatever we are doing in here. This is why we need the return type of 'Task<Unit>' in the signature
                // A unit is a MediatR struct that represents a void or null value.
                return Unit.Value;

            }
        }
    }
}
