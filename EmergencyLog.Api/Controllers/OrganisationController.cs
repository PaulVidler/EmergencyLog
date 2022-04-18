using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.Organisations;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<Organisation>> GetOrganisations()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{guid}")]
        public async Task<Organisation> GetOrganisation(Guid guid)
        {
            return await Mediator.Send(new Details.Query { Id = guid });
        }

        [HttpPost]
        public async Task<IActionResult> PostOrganisation(Organisation organisation)
        {
            return Ok(await Mediator.Send(new Create.Command { Organisation = organisation }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrganisation(Guid id, Organisation organisation)
        {
            organisation.OrganisationId = id;
            return Ok(await Mediator.Send(new Edit.Command { Organisation = organisation }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisation(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
