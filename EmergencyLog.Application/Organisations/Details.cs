using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Organisations
{
    public class Details
    {
        public class Query : IRequest<Result<Organisation>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<Organisation>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Organisation>> Handle(Query request, CancellationToken cancellationToken)
            {
                var organisation = await _context.Organisations.FindAsync(request.Id);
                return Result<Organisation>.Success(organisation);
            }
        }
    }
}
