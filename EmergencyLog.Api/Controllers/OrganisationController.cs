using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
            return HandlePagedResult(await Mediator.Send(new ListQuery<Organisation> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetOrganisation(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Organisation> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostOrganisation(OrganisationResultDto organisation)
        {
            var organisationEntity = _mapper.Map<OrganisationResultDto, Organisation>(organisation);
            return HandleResult(await Mediator.Send(new CreateCommand<Organisation> { Type = organisationEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrganisation(int id, Organisation organisation)
        {
            organisation.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Organisation> { Type = organisation }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisation(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Organisation> { Id = id }));
        }
    }
}
