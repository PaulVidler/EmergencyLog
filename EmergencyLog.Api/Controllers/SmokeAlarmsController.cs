using AutoMapper;
using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.SmokeAlarmDtos;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmokeAlarmsController : BaseApiController
    {
        private IMapper _mapper;

        public SmokeAlarmsController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSmokeAlarms([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<SmokeAlarmResultDto> { Params = pagingParams }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmokeAlarm(int id)
        {
            return HandleResult( await Mediator.Send(new DetailsQuery<SmokeAlarmResultDto> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(SmokeAlarmAddDto smokeAlarm)
        {
            var smokeAlarmEntity = _mapper.Map<SmokeAlarm>(smokeAlarm);
            return HandleResult(await Mediator.Send(new CreateCommand<SmokeAlarm> { Type = smokeAlarmEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSmokeAlarm(int id, SmokeAlarmEditDto smokeAlarm)
        {
            var mappedSmokeAlarm = _mapper.Map<SmokeAlarm>(smokeAlarm);
            mappedSmokeAlarm.Id = id;
            
            return HandleResult(await Mediator.Send(new EditCommand<SmokeAlarm> { Type = mappedSmokeAlarm }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmokeAlarm(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<SmokeAlarm> { Id = id }));
        }
    }
}
