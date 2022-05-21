using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application;
using EmergencyLog.Application.DTOs.PropertyDtos;
using EmergencyLog.Application.Property;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseApiController
    {
        private IMapper _mapper;

        public PropertyController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<Property> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Property> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostProperty(PropertyResultDto property)
        {
            var propertyEntity = _mapper.Map<PropertyResultDto, Property>(property);
            return HandleResult(await Mediator.Send(new CreateCommand<Property> { Type = propertyEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProperty(int id, Property property)
        {
            property.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Property> { Type = property }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Property> { Id = id }));
        }
    }
}
