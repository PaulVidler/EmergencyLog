using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.EmergencyContactDtos;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class ListHandler : IRequestHandler<ListQuery<EmergencyContactResultDto>, Result<PagedList<EmergencyContactResultDto>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<EmergencyContactResultDto>>> Handle(ListQuery<EmergencyContactResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<EmergencyContact, EmergencyContactResultDto>());

            var query = _context.EmergencyContacts.Where(d => d.IsDeleted == false).OrderBy(d => d.Surname)
                .ProjectTo<EmergencyContactResultDto>(configuration).AsQueryable();

            return Result<PagedList<EmergencyContactResultDto>>.Success(
                await PagedList<EmergencyContactResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
