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
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<FireExtinguisher>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<FireExtinguisher>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PagedList<FireExtinguisher>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.FireExtinguishers.OrderBy(d => d.LastServiced).AsQueryable();

                return Result<PagedList<FireExtinguisher>>.Success(
                    await PagedList<FireExtinguisher>.CreateAsync(query, request.Params.PageNumber,
                        request.Params.PageSize));
            }
        }

    }
}
