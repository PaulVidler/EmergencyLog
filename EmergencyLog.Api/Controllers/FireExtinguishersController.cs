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
    public class FireExtinguishersController : BaseApiController
    {
        public FireExtinguishersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetFireExtinguishers([FromQuery]PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<FireExtinguisher> {Params = pagingParams}));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetFireExtinguisher(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<FireExtinguisher> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostFireExtinguisher(FireExtinguisher fireExtinguisher)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<FireExtinguisher> { Type = fireExtinguisher }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireExtinguisher(Guid id, FireExtinguisher fireExtinguisher)
        {
            fireExtinguisher.GlobalId = id;
            return HandleResult(await Mediator.Send(new EditCommand<FireExtinguisher> { Type = fireExtinguisher }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireExtinguisher(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<FireExtinguisher> { Id = id }));
        }
    }
}
