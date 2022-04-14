using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class Create
    {
        public class Command : IRequest
        {
            public FireExtinguisher FireExtinguisher { get; set; }
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
                _context.FireExtinguishers.Add(request.FireExtinguisher);
                await _context.SaveChangesAsync();
                
                return Unit.Value;

            }
        }
    }
}
