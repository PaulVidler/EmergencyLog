using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmergencyContact = EmergencyLog.Domain.Entities.EmergencyContact;

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
        public async Task<IActionResult> GetEmergencyContacts([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<EmergencyContact> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetEmergencyContact(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<EmergencyContact> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostEmergencyContact(EmergencyContact emergencyContact)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<EmergencyContact> { Type = emergencyContact }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmergencyContact(Guid id, EmergencyContact emergencyContact)
        {
            emergencyContact.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<EmergencyContact> { Type = emergencyContact }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergencyContact(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<EmergencyContact> { Id = id }));
        }
    }
}
