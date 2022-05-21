using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.Attendance;
using EmergencyLog.Application.DTOs.EmergencyContactDtos;
using EmergencyLog.Application.EmergencyContacts;
using EmergencyLog.Domain.Entities;
using EmergencyContact = EmergencyLog.Domain.Entities.EmergencyContact;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactsController : BaseApiController
    {
        private IMapper _mapper;

        public EmergencyContactsController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmergencyContacts([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<EmergencyContact> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetEmergencyContact(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<EmergencyContact> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostEmergencyContact(EmergencyContactResultDto emergencyContact)
        {
            var emergencyContactEntity = _mapper.Map<EmergencyContactResultDto, EmergencyContact>(emergencyContact);
            return HandleResult(await Mediator.Send(new CreateCommand<EmergencyContact> { Type = emergencyContactEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmergencyContact(int id, EmergencyContact emergencyContact)
        {
            emergencyContact.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<EmergencyContact> { Type = emergencyContact }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergencyContact(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<EmergencyContact> { Id = id }));
        }
    }
}
