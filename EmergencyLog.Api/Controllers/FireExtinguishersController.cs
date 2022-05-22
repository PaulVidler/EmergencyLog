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
            return HandlePagedResult(await Mediator.Send(new ListQuery<FireExtinguisherResultDto> {Params = pagingParams}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFireExtinguisher(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<FireExtinguisherResultDto> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostFireExtinguisher(FireExtinguisherAddDto fireExtinguisher)
        {
            var fireExtinguisherEntity = _mapper.Map<FireExtinguisher>(fireExtinguisher);
            return HandleResult(await Mediator.Send(new CreateCommand<FireExtinguisher> { Type = fireExtinguisherEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireExtinguisher(int id, FireExtinguisherEditDto fireExtinguisher)
        {
            var mappedFireExtinguisher = _mapper.Map<FireExtinguisher>(fireExtinguisher);
            mappedFireExtinguisher.Id = id;

            return HandleResult(await Mediator.Send(new EditCommand<FireExtinguisher> { Type = mappedFireExtinguisher }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireExtinguisher(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<FireExtinguisher> { Id = id }));
        }
    }
}
