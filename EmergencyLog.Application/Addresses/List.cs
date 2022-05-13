using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.Identity;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.Addresses
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<Address>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<Address>>>
        {
            private DataContext _context;
            // private UserManager<AppUser> _userManager;

            public Handler(DataContext context, UserManager<AppUser> userManager)
            {
                // _userManager = userManager;
                _context = context;
            }

            public async Task<Result<PagedList<Address>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // var orgId = request.Claim.Where(t => t.Type == "OrganisationId").Select(v => v.Value).FirstOrDefault();
                
                var query = _context.Addresses.OrderBy(d => d.Country).AsQueryable();
                
                return Result<PagedList<Address>>.Success(
                    await PagedList<Address>.CreateAsync(query, request.Params.PageNumber,
                        request.Params.PageSize));
            }
        }

    }
}
