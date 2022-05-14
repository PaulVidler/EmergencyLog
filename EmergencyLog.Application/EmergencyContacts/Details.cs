using EmergencyLog.Application.Core;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class DetailsHandler : IRequestHandler<DetailsQuery<EmergencyContact>, Result<EmergencyContact>>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<EmergencyContact>> Handle(DetailsQuery<EmergencyContact> request, CancellationToken cancellationToken)
        {
            var emergencyContact = await _context.EmergencyContacts.FindAsync(request.Id);
            return Result<EmergencyContact>.Success(emergencyContact);
        }
    }
}
