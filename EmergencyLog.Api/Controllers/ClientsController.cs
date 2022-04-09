using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using List = EmergencyLog.Application.Clients.List;
using EmergencyLog.Application.Clients;

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
        public async Task<List<Client>> GetClients()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{guid}")]
        public async Task<Client> GetClient(Guid guid)
        {
            return await Mediator.Send(new Details.Query { Guid = guid });
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(Client client)
        {
            return Ok(await Mediator.Send(new Create.Command{Client = client}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClient(Guid id, Client client)
        {
            client.Guid = id;
            return Ok(await Mediator.Send(new Edit.Command { Client = client }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
