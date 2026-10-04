using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.FireHoseDtos;

namespace EmergencyLog.Application.FireHoses
{
    public class ListHandler : IRequestHandler<ListQuery<FireHoseResultDto>, Result<PagedList<FireHoseResultDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<FireHoseResultDto>>> Handle(ListQuery<FireHoseResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.FireHoses
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.Id)
                .ProjectTo<FireHoseResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<FireHoseResultDto>>.Success(
                await PagedList<FireHoseResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
