using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.FireExtinguishers;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<FireExtinguisher>> GetFireExtinguisher()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{guid}")]
        public async Task<FireExtinguisher> GetFireExtinguisher(Guid guid)
        {
            return await Mediator.Send(new Details.Query { Id = guid });
        }

        [HttpPost]
        public async Task<IActionResult> PostFireExtinguisher(FireExtinguisher fireExtinguisher)
        {
            return Ok(await Mediator.Send(new Create.Command { FireExtinguisher = fireExtinguisher }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireExtinguisher(Guid id, FireExtinguisher fireExtinguisher)
        {
            fireExtinguisher.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { FireExtinguisher = fireExtinguisher }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireExtinguisher(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
