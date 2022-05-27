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
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<OrganisationResultDto>>> Handle(ListQuery<OrganisationResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<Organisation, OrganisationResultDto>());

            var query = _context.Organisations.Where(d => d.IsDeleted == false).OrderBy(d => d.OrganisationName)
                .ProjectTo<OrganisationResultDto>(configuration).AsQueryable();

            return Result<PagedList<OrganisationResultDto>>.Success(
                await PagedList<OrganisationResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
