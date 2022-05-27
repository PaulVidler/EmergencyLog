using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.PropertyDtos;

namespace EmergencyLog.Application.Property
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<PropertyResultDto>, Result<PropertyResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<PropertyResultDto>> Handle(DetailsQuery<PropertyResultDto> request, CancellationToken cancellationToken)
        {
            var property = await _context.Properties.FindAsync(request.Id);

            if (property == null)
            {
                return Result<PropertyResultDto>.Failure("Property not found");
            }
            if (property.IsDeleted)
            {
                return Result<PropertyResultDto>.Failure("This Property appears to be deleted in the database");
            }

            return Result<PropertyResultDto>.Success(_mapper.Map<PropertyResultDto>(property));
        }
    }
}
