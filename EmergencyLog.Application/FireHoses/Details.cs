using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.FireHoseDtos;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireHoses
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<FireHoseResultDto>, Result<FireHoseResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<FireHoseResultDto>> Handle(DetailsQuery<FireHoseResultDto> request, CancellationToken cancellationToken)
        {
            var fireHose = await _context.FireHoses.FindAsync(request.Id);

            if (fireHose == null)
            {
                return Result<FireHoseResultDto>.Failure("Fire Hose not found");
            }
            if (fireHose.IsDeleted)
            {
                return Result<FireHoseResultDto>.Failure("This Fire Hose appears to be deleted in the database");
            }
            
            return Result<FireHoseResultDto>.Success(_mapper.Map<FireHoseResultDto>(fireHose));
        }
    }
}