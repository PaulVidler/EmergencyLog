using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyLog.Application.Attendance;
using EmergencyLog.Domain;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using List = EmergencyLog.Application.Attendance.List;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAttendances()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetAttendance(Guid guid)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAttendance(Attendance attendance)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Attendance = attendance }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAttendance(Guid id, Attendance attendance)
        {
            attendance.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Attendance = attendance }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
