using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.FireExtinguisherDtos;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireExtinguishers
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<FireExtinguisherResultDto>, Result<FireExtinguisherResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<FireExtinguisherResultDto>> Handle(DetailsQuery<FireExtinguisherResultDto> request, CancellationToken cancellationToken)
        {
            var fireExtinguisher = await _context.FireExtinguishers.FindAsync(request.Id);

            if (fireExtinguisher == null)
            {
                return Result<FireExtinguisherResultDto>.Failure("Fire Extinguisher Hose not found");
            }
            if (fireExtinguisher.IsDeleted)
            {
                return Result<FireExtinguisherResultDto>.Failure("This Fire Extinguisher appears to be deleted in the database");
            }

            return Result<FireExtinguisherResultDto>.Success(_mapper.Map<FireExtinguisherResultDto>(fireExtinguisher));
        }
    }
}
