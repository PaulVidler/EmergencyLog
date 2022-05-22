using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmergencyLog.Application.DTOs.FireHoseDtos;

namespace EmergencyLog.Application.FireHoses
{
    public class ListHandler : IRequestHandler<ListQuery<FireHoseResultDto>, Result<PagedList<FireHoseResultDto>>>
    {
        private DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<PagedList<FireHoseResultDto>>> Handle(ListQuery<FireHoseResultDto> request, CancellationToken cancellationToken)
        {
            // config to be passed into ProjectTo method below.
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateProjection<FireHose, FireHoseResultDto>());

            var query = _context.FireHoses.Where(d => d.IsDeleted == false).OrderBy(d => d.Id)
                .ProjectTo<FireHoseResultDto>(configuration).AsQueryable();

            return Result<PagedList<FireHoseResultDto>>.Success(
                await PagedList<FireHoseResultDto>.CreateAsync(query, request.Params.PageNumber,
                    request.Params.PageSize));
        }
    }
}
