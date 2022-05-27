using AutoMapper;
using EmergencyLog.Application;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.AttendanceDtos;
using EmergencyLog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            return HandlePagedResult(await Mediator.Send(new ListQuery<AttendanceResultDto> { Params = pagingParams }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance(int id)
        {
            return HandleResult(await Mediator.Send(new DetailsQuery<AttendanceResultDto> { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAttendance(AttendanceAddDto attendance)
        {
            var attendanceEntity = _mapper.Map<Attendance>(attendance);
            return HandleResult(await Mediator.Send(new CreateCommand<Attendance> { Type = attendanceEntity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAttendance(int id, AttendanceEditDto attendance)
        {
            return HandleResult(await Mediator.Send(new EditCommand<AttendanceEditDto> { Type = attendance }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand<Attendance> { Id = id }));
        }
    }
}
