using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class Details
    {
        public class Query : IRequest<Domain.Entities.FireExtinguisher>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Domain.Entities.FireExtinguisher>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Domain.Entities.FireExtinguisher> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FireExtinguishers.FindAsync(request.Id);
            }
        }
    }
}
