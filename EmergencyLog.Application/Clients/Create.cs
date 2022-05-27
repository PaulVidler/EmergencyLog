using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Application.DTOs.ClientDtos;

namespace EmergencyLog.Application.Clients
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand<Client>>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new ClientsValidator());
        }
    }

    public class CreateHandler : IRequestHandler<CreateCommand<Client>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public CreateHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreateCommand<Client> request, CancellationToken cancellationToken)
        {
            //var client = _mapper.Map<Client>(request.Type);
            
            _context.Clients.Add(request.Type);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Client");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
