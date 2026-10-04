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
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<EmergencyContactResultDto>>> Handle(ListQuery<EmergencyContactResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.EmergencyContacts
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.Surname)
                .ProjectTo<EmergencyContactResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<EmergencyContactResultDto>>.Success(
                await PagedList<EmergencyContactResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
