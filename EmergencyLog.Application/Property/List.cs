using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.PropertyDtos;

namespace EmergencyLog.Application.Property
{
    public class ListHandler : IRequestHandler<ListQuery<PropertyResultDto>, Result<PagedList<PropertyResultDto>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<PropertyResultDto>>> Handle(ListQuery<PropertyResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<Domain.Entities.Property, PropertyResultDto>());

            var query = _context.Properties.Where(d => d.IsDeleted == false).OrderBy(d => d.Country)
                .ProjectTo<PropertyResultDto>(configuration).AsQueryable();

            return Result<PagedList<PropertyResultDto>>.Success(
                await PagedList<PropertyResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
