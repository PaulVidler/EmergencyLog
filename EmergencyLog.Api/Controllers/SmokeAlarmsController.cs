using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application;
using EmergencyLog.Application.DTOs.SmokeAlarmDtos;
using EmergencyLog.Application.SmokeAlarms;

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
            return HandlePagedResult(await Mediator.Send(new ListQuery<SmokeAlarm> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSmokeAlarm(int id)
        {
            return HandleResult( await Mediator.Send(new DetailsQuery<SmokeAlarm> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(SmokeAlarmResultDto smokeAlarm)
        {
            var smokeAlarmEntity = _mapper.Map<SmokeAlarmResultDto, SmokeAlarm>(smokeAlarm);
            return HandleResult(await Mediator.Send(new CreateCommand<SmokeAlarm> { Type = smokeAlarmEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSmokeAlarm(int id, SmokeAlarm smokeAlarm)
        {
            smokeAlarm.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<SmokeAlarm> { Type = smokeAlarm }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmokeAlarm(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<SmokeAlarm> { Id = id }));
        }
    }
}
