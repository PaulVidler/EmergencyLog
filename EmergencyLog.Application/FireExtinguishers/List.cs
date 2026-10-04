using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.FireExtinguisherDtos;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class ListHandler : IRequestHandler<ListQuery<FireExtinguisherResultDto>, Result<PagedList<FireExtinguisherResultDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<FireExtinguisherResultDto>>> Handle(ListQuery<FireExtinguisherResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.FireExtinguishers
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.LastServiced)
                .ProjectTo<FireExtinguisherResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<FireExtinguisherResultDto>>.Success(
                await PagedList<FireExtinguisherResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
