using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.FireExtinguisherDtos;
using EmergencyLog.Application.FireExtinguishers;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireExtinguishersController : BaseApiController
    {
        private IMapper _mapper;

        public FireExtinguishersController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFireExtinguishers([FromQuery]PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<FireExtinguisher> {Params = pagingParams}));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetFireExtinguisher(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<FireExtinguisher> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostFireExtinguisher(FireExtinguisherResultDto fireExtinguisher)
        {
            var fireExtinguisherEntity = _mapper.Map<FireExtinguisherResultDto, FireExtinguisher>(fireExtinguisher);
            return HandleResult(await Mediator.Send(new CreateCommand<FireExtinguisher> { Type = fireExtinguisherEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireExtinguisher(int id, FireExtinguisher fireExtinguisher)
        {
            fireExtinguisher.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<FireExtinguisher> { Type = fireExtinguisher }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireExtinguisher(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<FireExtinguisher> { Id = id }));
        }
    }
}
