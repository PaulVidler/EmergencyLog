using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmergencyLog.Application;

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
            return HandlePagedResult(await Mediator.Send(new ListQuery<Property> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetProperty(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Property> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostProperty(Property property)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<Property> { Type = property }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProperty(Guid id, Property property)
        {
            property.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Property> { Type = property }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Property> { Id = id }));
        }
    }
}
