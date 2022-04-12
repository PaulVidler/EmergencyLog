using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Property
{
    public class Details
    {
        public class Query : IRequest<Domain.Entities.Property>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Domain.Entities.Property>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Domain.Entities.Property> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Properties.FindAsync(request.Id);
            }
        }
    }
}
