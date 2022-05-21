using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.Attendance;
using EmergencyLog.Application.DTOs.FireHoseDtos;
using EmergencyLog.Application.FireHoses;
using EmergencyLog.Domain.Entities;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireHosesController : BaseApiController
    {
        private IMapper _mapper;

        public FireHosesController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFireHoses([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<FireHose> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetFireHose(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<FireHose> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostFireHose(FireHoseResultDto fireHose)
        {
            var fireHoseEntity = _mapper.Map<FireHoseResultDto, FireHose>(fireHose);
            return HandleResult(await Mediator.Send(new CreateCommand<FireHose> { Type = fireHoseEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireHose(int id, FireHose fireHose)
        {
            fireHose.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<FireHose> { Type = fireHose }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireHose(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<FireHose> { Id = id }));
        }
    }
}
