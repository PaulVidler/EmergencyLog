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
    public class AttendancesController : BaseApiController
    {
        public AttendancesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendances([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<Attendance> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetAttendance(Guid guid)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Attendance> { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAttendance(Attendance attendance)
        {
            return HandleResult(await Mediator.Send(new CreateCommand<Attendance> { GenericType = attendance }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAttendance(Guid id, Attendance attendance)
        {
            attendance.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Attendance> { GenericType = attendance }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand { Id = id }));
        }
    }
}
