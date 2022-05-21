using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.AttendanceDtos;

namespace EmergencyLog.Application.Attendance
{
    public class ListHandler : IRequestHandler<ListQuery<AttendanceResultDto>, Result<PagedList<AttendanceResultDto>>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<PagedList<AttendanceResultDto>>> Handle(ListQuery<AttendanceResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.Attendances.OrderBy(d => d.TimeOut).AsQueryable();
            
            return Result<PagedList<AttendanceResultDto>>.Success(
                await PagedList<AttendanceResultDto>.CreateAsync(_mapper.Map<IQueryable<AttendanceResultDto>>(query), request.Params.PageNumber,
                    request.Params.PageSize));

            //return Result<PagedList<AttendanceResultDto>>.Success(
            //    await PagedList<AttendanceResultDto>.CreateAsync(query, request.Params.PageNumber,
            //        request.Params.PageSize));
        }
    }
}
