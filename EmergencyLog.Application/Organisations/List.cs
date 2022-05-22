using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.OrganisationDtos;

namespace EmergencyLog.Application.Organisations
{
    public class ListHandler : IRequestHandler<ListQuery<OrganisationResultDto>, Result<PagedList<OrganisationResultDto>>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<PagedList<OrganisationResultDto>>> Handle(ListQuery<OrganisationResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.Organisations.OrderBy(d => d.OrganisationName).AsQueryable();

            var mappedQuery = _mapper.Map<IQueryable<Organisation>, IQueryable<OrganisationResultDto>>(query);

            return Result<PagedList<OrganisationResultDto>>.Success(
                await PagedList<OrganisationResultDto>.CreateAsync(mappedQuery, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
