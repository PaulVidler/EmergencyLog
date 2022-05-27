using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.OrganisationDtos;

namespace EmergencyLog.Application.Organisations
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<OrganisationResultDto>, Result<OrganisationResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<OrganisationResultDto>> Handle(DetailsQuery<OrganisationResultDto> request, CancellationToken cancellationToken)
        {
            var organisation = await _context.Organisations.FindAsync(request.Id);

            if (organisation == null)
            {
                return Result<OrganisationResultDto>.Failure("Organisation not found");
            }
            if (organisation.IsDeleted)
            {
                return Result<OrganisationResultDto>.Failure("This Organisation appears to be deleted in the database");
            }

            return Result<OrganisationResultDto>.Success(_mapper.Map<OrganisationResultDto>(organisation));
        }
    }
}
