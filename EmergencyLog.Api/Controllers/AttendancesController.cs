using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmergencyLog.Application.Attendance;

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
        public async Task<IActionResult> PostAttendance(AttendanceDto attendance)
        {
            // create entity model here from DTO BEFORE sending to the handler
            Attendance attendanceEntity = new Attendance()
            {
                GlobalId = Guid.NewGuid(),
                TimeIn = attendance.TimeIn,
                TimeOut = attendance.TimeOut,
                OnSite = attendance.OnSite,
                EntryComplete = attendance.EntryComplete,
                ClientId = attendance.ClientId
            };

            return HandleResult(await Mediator.Send(new CreateCommand<Attendance> { Type = attendanceEntity }));

            // return HandleResult(await Mediator.Send(new CreateCommand<AttendanceDto> { Type = attendance }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAttendance(Guid id, Attendance attendance)
        {
            attendance.GlobalId = id;
            return HandleResult(await Mediator.Send(new EditCommand<Attendance> { Type = attendance }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Attendance> { Id = id }));
        }
    }
}
