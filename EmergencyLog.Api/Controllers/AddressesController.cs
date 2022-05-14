using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseApiController
    {
        public AddressesController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAddresses([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<Address> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetAddress(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Address> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(Address address)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<Address> { Type = address }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddress(Guid id, Address address)
        {
            address.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Address> { Type = address }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Address> { Id = id }));
        }
    }
}
