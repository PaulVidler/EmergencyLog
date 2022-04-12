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
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var FireExtinguisher = await _context.FireExtinguishers.FindAsync(request.Id);
                _context.Remove(FireExtinguisher);

                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
