using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.FireHoses
{
    public class Details
    {
        public class Query : IRequest<Domain.Entities.FireHose>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Domain.Entities.FireHose>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Domain.Entities.FireHose> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FireHoses.FindAsync(request.Id);
            }
        }
    }
}
