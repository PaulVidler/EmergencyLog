using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.OrganisationDtos;

namespace EmergencyLog.Application.Organisations
{
    public class ListHandler : IRequestHandler<ListQuery<OrganisationResultDto>, Result<PagedList<OrganisationResultDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<OrganisationResultDto>>> Handle(ListQuery<OrganisationResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.Organisations
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.OrganisationName)
                .ProjectTo<OrganisationResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<OrganisationResultDto>>.Success(
                await PagedList<OrganisationResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
