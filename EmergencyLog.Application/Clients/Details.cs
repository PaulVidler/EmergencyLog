using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Clients
{
    public class Details
    {
        public class Query : IRequest<Domain.Entities.Client>
        {
            public Guid Guid { get; set; }
        }

        public class Handler : IRequestHandler<Query, Domain.Entities.Client>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Domain.Entities.Client> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Clients.FindAsync(request.Guid); 
            }
        }
    }
}
