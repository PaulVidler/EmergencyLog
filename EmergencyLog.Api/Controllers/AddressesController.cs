using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.Addresses;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using List = EmergencyLog.Application.Addresses.List;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<Address>> GetAddresses()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{guid}")]
        public async Task<Address> GetAddress(Guid guid)
        {
            return await Mediator.Send(new Details.Query { Id = guid });
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(Address Address)
        {
            return Ok(await Mediator.Send(new Create.Command { Address = Address }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddress(Guid id, Address Address)
        {
            Address.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Address = Address }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
