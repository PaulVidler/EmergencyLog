using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.Attendance;
using EmergencyLog.Application.DTOs.AttendanceDtos;

namespace EmergencyLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : BaseApiController
    {
        private IMapper _mapper;

        public AttendancesController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendances([FromQuery] PagingParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new ListQuery<Attendance> { Params = pagingParams }));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetAttendance(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<Attendance> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAttendance(AttendanceAddDto attendance)
        {
            //var attendanceEntity = _mapper.Map<AttendanceAddDto, Attendance>(attendance);

            return HandleResult(await Mediator.Send(new CreateCommand<AttendanceAddDto> { Type = attendance }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAttendance(int id, Attendance attendance)
        {
            attendance.Id = id;
            return HandleResult(await Mediator.Send(new EditCommand<Attendance> { Type = attendance }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Attendance> { Id = id }));
        }
    }
}
