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
            return HandlePagedResult(await Mediator.Send(new ListQuery<ClientResultDto> { Params = pagingParams }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<ClientResultDto> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(ClientAddDto client)
        {
            Client clientEntity = new Client();
            clientEntity = _mapper.Map(client, clientEntity);
            return HandleResult(await Mediator.Send(new CreateCommand<Client> { Type = clientEntity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClient(int id, ClientEditDto client)
        {
            return HandleResult(await Mediator.Send(new EditCommand<ClientEditDto> { Type = client }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Client> { Id = id }));
        }
    }
}
