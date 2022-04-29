﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var emergencyContact = await _context.EmergencyContacts.FindAsync(request.Id);
                if (emergencyContact == null) return null;

                _context.Remove(emergencyContact);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to delete EmergencyContact");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
