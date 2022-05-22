using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.ClientDtos;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.Clients
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<ClientResultDto>, Result<ClientResultDto>>
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public DetailsHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<ClientResultDto>> Handle(DetailsQuery<ClientResultDto> request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FindAsync(request.Id);

            if (client == null)
            {
                return Result<ClientResultDto>.Failure("Client not found");
            }
            if (client.IsDeleted)
            {
                return Result<ClientResultDto>.Failure("This Client appears to be deleted in the database");
            }

            return Result<ClientResultDto>.Success(_mapper.Map<ClientResultDto>(client));
        }
    }
}