using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : BaseApiController
    {
        public OrganisationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganisations([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<Organisation> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetOrganisation(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Organisation> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostOrganisation(Organisation organisation)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<Organisation> { Type = organisation }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrganisation(Guid id, Organisation organisation)
        {
            organisation.GlobalId = id;
            return HandleResult(await Mediator.Send(new EditCommand<Organisation> { Type = organisation }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisation(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Organisation> { Id = id }));
        }
    }
}
