using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            return HandlePagedResult(await Mediator.Send(new ListQuery<FireHose> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetFireHose(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<FireHose> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostFireHose(FireHose fireHose)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<FireHose> { Type = fireHose }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireHose(Guid id, FireHose fireHose)
        {
            fireHose.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<FireHose> { Type = fireHose }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireHose(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<FireHose> { Id = id }));
        }
    }
}
