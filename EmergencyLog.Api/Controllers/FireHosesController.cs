using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.FireHoses;
using EmergencyLog.Domain.Entities;
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
        public async Task<List<FireHose>> GetFireHoses()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{guid}")]
        public async Task<FireHose> GetFireHose(Guid guid)
        {
            return await Mediator.Send(new Details.Query { Id = guid });
        }

        [HttpPost]
        public async Task<IActionResult> PostFireHose(FireHose fireHose)
        {
            return Ok(await Mediator.Send(new Create.Command { FireHose = fireHose }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireHose(Guid id, FireHose fireHose)
        {
            fireHose.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { FireHose = fireHose }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
