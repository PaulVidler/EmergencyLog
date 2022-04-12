using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Organisations
{
    public class Details
    {
        public class Query : IRequest<Domain.Entities.Organisation>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Domain.Entities.Organisation>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Domain.Entities.Organisation> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Organisations.FindAsync(request.Id);
            }
        }
    }
}
