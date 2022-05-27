using AutoMapper;
using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.FireHoseDtos;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            return HandlePagedResult(await Mediator.Send(new ListQuery<FireHoseResultDto> { Params = pagingParams }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFireHose(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<FireHoseResultDto> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostFireHose(FireHoseAddDto fireHose)
        {
            var fireHoseEntity = _mapper.Map<FireHose>(fireHose);
            return HandleResult(await Mediator.Send(new CreateCommand<FireHose> { Type = fireHoseEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFireHose(int id, FireHoseEditDto fireHose)
        {
            return HandleResult(await Mediator.Send(new EditCommand<FireHoseEditDto> { Type = fireHose }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireHose(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<FireHose> { Id = id }));
        }
    }
}
