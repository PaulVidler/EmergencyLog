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
        public async Task<List<Attendance>> GetAttendances()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{guid}")]
        public async Task<Attendance> GetAttendance(Guid guid)
        {
            return await Mediator.Send(new Details.Query { Id = guid });
        }

        [HttpPost]
        public async Task<IActionResult> PostAttendance(Attendance Attendance)
        {
            return Ok(await Mediator.Send(new Create.Command { Attendance = Attendance }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAttendance(Guid id, Attendance Attendance)
        {
            Attendance.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Attendance = Attendance }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
