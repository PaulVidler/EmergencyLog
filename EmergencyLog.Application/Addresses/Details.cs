using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.Addresses
{
    public class Details
    {
        public class Query : IRequest<Result<Address>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<Address>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Address>> Handle(Query request, CancellationToken cancellationToken)
            {
                var address = await _context.Addresses.FindAsync(request.Id);
                return Result<Address>.Success(address);
            }
        }
    }
}
