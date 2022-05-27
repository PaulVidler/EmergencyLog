using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.AttendanceDtos;

namespace EmergencyLog.Application.Attendance
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<AttendanceResultDto>, Result<AttendanceResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<AttendanceResultDto>> Handle(DetailsQuery<AttendanceResultDto> request, CancellationToken cancellationToken)
        {
            var attendance = await _context.Attendances.FindAsync(request.Id);

            if (attendance == null)
            {
                return Result<AttendanceResultDto>.Failure("Attendance not found");
            }
            if (attendance.IsDeleted)
            {
                return Result<AttendanceResultDto>.Failure("This Attendance appears to be deleted in the database");
            }

            return Result<AttendanceResultDto>.Success(_mapper.Map<AttendanceResultDto>(attendance));
        }
    }
}
