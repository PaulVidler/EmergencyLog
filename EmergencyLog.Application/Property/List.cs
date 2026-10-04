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
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<PropertyResultDto>>> Handle(ListQuery<PropertyResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.Properties
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.Country)
                .ProjectTo<PropertyResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<PropertyResultDto>>.Success(
                await PagedList<PropertyResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
