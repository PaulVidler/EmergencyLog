using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.SmokeAlarms;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetSmokeAlarms()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSmokeAlarm(Guid guid)
        {
            return HandleResult( await Mediator.Send(new Details.Query { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(SmokeAlarm smokeAlarm)
        {
            return HandleResult(await Mediator.Send(new Create.Command { SmokeAlarm = smokeAlarm }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSmokeAlarm(Guid id, SmokeAlarm smokeAlarm)
        {
            smokeAlarm.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { SmokeAlarm = smokeAlarm }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmokeAlarm(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
