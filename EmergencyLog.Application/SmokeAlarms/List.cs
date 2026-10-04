using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.SmokeAlarmDtos;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class ListHandler : IRequestHandler<ListQuery<SmokeAlarmResultDto>, Result<PagedList<SmokeAlarmResultDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<SmokeAlarmResultDto>>> Handle(ListQuery<SmokeAlarmResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.SmokeAlarms
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.LastServiced)
                .ProjectTo<SmokeAlarmResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<SmokeAlarmResultDto>>.Success(
                await PagedList<SmokeAlarmResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
