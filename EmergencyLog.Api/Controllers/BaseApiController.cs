using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // '??=' null coelescing assignment operator. If '_mediator' is null, 'GetServices()' on the right of ??= will be assigned to 'Mediator' property
        // I think 'HttpContext.RequestServices.GetService<IMediator>()' is just getting the service if it's not injected for some reason?
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
