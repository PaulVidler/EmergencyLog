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
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<ClientResultDto>>> Handle(ListQuery<ClientResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<Client, ClientResultDto>());

            var query = _context.Clients.Where(d => d.IsDeleted == false).OrderBy(d => d.Surname)
                .ProjectTo<ClientResultDto>(configuration).AsQueryable();

            return Result<PagedList<ClientResultDto>>.Success(
                await PagedList<ClientResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
