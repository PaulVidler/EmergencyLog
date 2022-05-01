using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.FireHoses;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireHosesController : BaseApiController
    {
        public FireHosesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetFireHoses([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetFireHose(Guid guid)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostFireHose(FireHose fireHose)
        {
            return HandleResult(await Mediator.Send(new Create.Command { FireHose = fireHose }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireHose(Guid id, FireHose fireHose)
        {
            fireHose.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { FireHose = fireHose }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireHose(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
