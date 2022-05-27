using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.EmergencyContactDtos;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<EmergencyContactResultDto>, Result<EmergencyContactResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<EmergencyContactResultDto>> Handle(DetailsQuery<EmergencyContactResultDto> request, CancellationToken cancellationToken)
        {
            var emergencyContact = await _context.EmergencyContacts.FindAsync(request.Id);

            if (emergencyContact == null)
            {
                return Result<EmergencyContactResultDto>.Failure("Emergency Contact not found");
            }
            if (emergencyContact.IsDeleted)
            {
                return Result<EmergencyContactResultDto>.Failure("This Emergency Contact appears to be deleted in the database");
            }

            return Result<EmergencyContactResultDto>.Success(_mapper.Map<EmergencyContactResultDto>(emergencyContact));
        }
    }
}
