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
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.Property
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<Domain.Entities.Property>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<Domain.Entities.Property>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PagedList<Domain.Entities.Property>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Properties.OrderBy(d => d.Address.Country).AsQueryable();

                return Result<PagedList<Domain.Entities.Property>>.Success(
                    await PagedList<Domain.Entities.Property>.CreateAsync(query, request.Params.PageNumber,
                        request.Params.PageSize));
            }
        }

    }
}
