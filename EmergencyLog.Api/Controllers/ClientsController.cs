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
    public class ClientsController : BaseApiController
    {
        public ClientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<Client> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetClient(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Client> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(Client client)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<Client> { Type = client}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClient(Guid id, Client client)
        {
            client.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Client> { Type = client }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Client> { Id = id }));
        }
    }
}
