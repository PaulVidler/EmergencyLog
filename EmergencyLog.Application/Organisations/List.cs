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

namespace EmergencyLog.Application.Organisations
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<Organisation>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<Organisation>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PagedList<Organisation>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Organisations.OrderBy(d => d.OrganisationName).AsQueryable();

                return Result<PagedList<Organisation>>.Success(
                    await PagedList<Organisation>.CreateAsync(query, request.Params.PageNumber,
                        request.Params.PageSize));
            }
        }

    }
}
