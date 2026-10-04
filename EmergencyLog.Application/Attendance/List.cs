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
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<AttendanceResultDto>>> Handle(ListQuery<AttendanceResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.Attendances
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.TimeOut)
                .ProjectTo<AttendanceResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<AttendanceResultDto>>.Success(
                await PagedList<AttendanceResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
