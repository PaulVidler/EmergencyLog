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

namespace EmergencyLog.Application.EmergencyContacts
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<EmergencyContact>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<EmergencyContact>>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PagedList<EmergencyContact>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.EmergencyContacts.OrderBy(d => d.Surname).AsQueryable();

                return Result<PagedList<EmergencyContact>>.Success(
                    await PagedList<EmergencyContact>.CreateAsync(query, request.Params.PageNumber,
                        request.Params.PageSize));
            }
        }

    }
}
