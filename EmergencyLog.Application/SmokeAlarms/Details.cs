using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.SmokeAlarmDtos;

namespace EmergencyLog.Application.SmokeAlarms
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<SmokeAlarmResultDto>, Result<SmokeAlarmResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<SmokeAlarmResultDto>> Handle(DetailsQuery<SmokeAlarmResultDto> request, CancellationToken cancellationToken)
        {
            var smokeAlarm = await _context.SmokeAlarms.FindAsync(request.Id);

            if (smokeAlarm == null)
            {
                return Result<SmokeAlarmResultDto>.Failure("Smoke alarm not found");
            }
            if (smokeAlarm.IsDeleted)
            {
                return Result<SmokeAlarmResultDto>.Failure("This Smoke Alarm appears to be deleted in the database");
            }

            return Result<SmokeAlarmResultDto>.Success(_mapper.Map<SmokeAlarmResultDto>(smokeAlarm));
        }
    }
}
