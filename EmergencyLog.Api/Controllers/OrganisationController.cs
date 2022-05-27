using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.OrganisationDtos;
using EmergencyLog.Application.Organisations;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : BaseApiController
    {
        private IMapper _mapper;

        public OrganisationController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganisations([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<OrganisationResultDto> { Params = pagingParams }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganisation(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<OrganisationResultDto> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostOrganisation(OrganisationAddDto organisation)
        {
            var organisationEntity = _mapper.Map<Organisation>(organisation);
            return HandleResult(await Mediator.Send(new CreateCommand<Organisation> { Type = organisationEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrganisation(int id, OrganisationEditDto organisation)
        {
            return HandleResult(await Mediator.Send(new EditCommand<OrganisationEditDto> { Type = organisation }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisation(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Organisation> { Id = id }));
        }
    }
}
