using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Property;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseApiController
    {
        public PropertyController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetProperty(Guid guid)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostProperty(Property property)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Property = property }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProperty(Guid id, Property property)
        {
            property.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Property = property }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
