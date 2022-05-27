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
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<SmokeAlarmResultDto>>> Handle(ListQuery<SmokeAlarmResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<SmokeAlarm, SmokeAlarmResultDto>());

            var query = _context.SmokeAlarms.Where(d => d.IsDeleted == false).OrderBy(d => d.LastServiced)
                .ProjectTo<SmokeAlarmResultDto>(configuration).AsQueryable();

            return Result<PagedList<SmokeAlarmResultDto>>.Success(
                await PagedList<SmokeAlarmResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
