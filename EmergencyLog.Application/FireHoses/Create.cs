﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;

namespace EmergencyLog.Application.FireHoses
{
    public class Create
    {
        public class Command : IRequest
        {
            public FireHose FireHose { get; set; }
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
                _context.FireHoses.Add(request.FireHose);
                await _context.SaveChangesAsync();
                
                return Unit.Value;

            }
        }
    }
}
