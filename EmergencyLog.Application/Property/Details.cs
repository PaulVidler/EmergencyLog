using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Property
{
    public class Details
    {
        public class Query : IRequest<Result<Domain.Entities.Property>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<Domain.Entities.Property>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Domain.Entities.Property>> Handle(Query request, CancellationToken cancellationToken)
            {
                var property = await _context.Properties.FindAsync(request.Id);
                return Result<Domain.Entities.Property>.Success(property);
            }
        }
    }
}
