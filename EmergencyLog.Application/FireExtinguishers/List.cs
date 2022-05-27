using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.FireExtinguisherDtos;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class ListHandler : IRequestHandler<ListQuery<FireExtinguisherResultDto>, Result<PagedList<FireExtinguisherResultDto>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<FireExtinguisherResultDto>>> Handle(ListQuery<FireExtinguisherResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<FireExtinguisher, FireExtinguisherResultDto>());

            var query = _context.FireExtinguishers.Where(d => d.IsDeleted == false).OrderBy(d => d.LastServiced)
                .ProjectTo<FireExtinguisherResultDto>(configuration).AsQueryable();

            return Result<PagedList<FireExtinguisherResultDto>>.Success(
                await PagedList<FireExtinguisherResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
