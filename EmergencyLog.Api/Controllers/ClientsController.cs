using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.Clients;
using EmergencyLog.Application.DTOs.ClientDtos;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : BaseApiController
    {
        private IMapper _mapper;

        public ClientsController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<Client> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetClient(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Client> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(ClientResultDto client)
        {
            var clientEntity = _mapper.Map<ClientResultDto, Client>(client);
            return HandleResult(await Mediator.Send(new CreateCommand<Client> { Type = clientEntity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClient(int id, Client client)
        {
            client.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Client> { Type = client }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Client> { Id = id }));
        }
    }
}
