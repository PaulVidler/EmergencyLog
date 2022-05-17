using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmergencyLog.Application;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmokeAlarmsController : BaseApiController
    {
        public SmokeAlarmsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetSmokeAlarms([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<SmokeAlarm> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSmokeAlarm(Guid guid)
        {
            return HandleResult( await Mediator.Send(new DetailsQuery<SmokeAlarm> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(SmokeAlarm smokeAlarm)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<SmokeAlarm> { Type = smokeAlarm }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSmokeAlarm(Guid id, SmokeAlarm smokeAlarm)
        {
            smokeAlarm.GlobalId = id;
            return HandleResult(await Mediator.Send(new EditCommand<SmokeAlarm> { Type = smokeAlarm }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmokeAlarm(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<SmokeAlarm> { Id = id }));
        }
    }
}
