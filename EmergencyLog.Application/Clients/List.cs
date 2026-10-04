using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.ClientDtos;

namespace EmergencyLog.Application.Clients
{
    public class ListHandler : IRequestHandler<ListQuery<ClientResultDto>, Result<PagedList<ClientResultDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<ClientResultDto>>> Handle(ListQuery<ClientResultDto> request, CancellationToken cancellationToken)
        {
            var query = _context.Clients
                .Where(d => d.IsDeleted == false)
                .OrderBy(d => d.Surname)
                .ProjectTo<ClientResultDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return Result<PagedList<ClientResultDto>>.Success(
                await PagedList<ClientResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
