using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.AttendanceDtos;

namespace EmergencyLog.Application.Attendance
{
    public class ListHandler : IRequestHandler<ListQuery<AttendanceResultDto>, Result<PagedList<AttendanceResultDto>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<AttendanceResultDto>>> Handle(ListQuery<AttendanceResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<Domain.Entities.Attendance, AttendanceResultDto>());

            var query = _context.Attendances.Where(d => d.IsDeleted == false).OrderBy(d => d.TimeOut)
                .ProjectTo<AttendanceResultDto>(configuration).AsQueryable();

            return Result<PagedList<AttendanceResultDto>>.Success(
                await PagedList<AttendanceResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
