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

namespace EmergencyLog.Application.EmergencyContacts
{
    public class Details
    {
        public class Query : IRequest<Result<EmergencyContact>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<EmergencyContact>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<EmergencyContact>> Handle(Query request, CancellationToken cancellationToken)
            {
                var emergencyContact = await _context.EmergencyContacts.FindAsync(request.Id);
                return Result<EmergencyContact>.Success(emergencyContact);
            }
        }
    }
}
