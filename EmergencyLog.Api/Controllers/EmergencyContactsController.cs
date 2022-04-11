using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.EmergencyContacts;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using List = EmergencyLog.Application.EmergencyContacts.List;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactsController : BaseApiController
    {
        public EmergencyContactsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<List<EmergencyContact>> GetEmergencyContacts()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{guid}")]
        public async Task<EmergencyContact> GetEmergencyContact(Guid guid)
        {
            return await Mediator.Send(new Details.Query { Id = guid });
        }

        [HttpPost]
        public async Task<IActionResult> PostEmergencyContact(EmergencyContact EmergencyContact)
        {
            return Ok(await Mediator.Send(new Create.Command { EmergencyContact = EmergencyContact }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmergencyContact(Guid id, EmergencyContact EmergencyContact)
        {
            EmergencyContact.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { EmergencyContact = EmergencyContact }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergencyContact(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
