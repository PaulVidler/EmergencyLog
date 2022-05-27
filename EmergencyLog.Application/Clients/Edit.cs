using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmergencyLog.Application.DTOs.ClientDtos;

namespace EmergencyLog.Application.Clients
{
    public class EditCommandValidator : AbstractValidator<EditCommand<Client>>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new ClientsValidator());
        }
    }

    public class EditHandler : IRequestHandler<EditCommand<ClientEditDto>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<ClientEditDto> request, CancellationToken cancellationToken)
        {

            var client = await _context.Clients.FindAsync(request.Type.Id);

            if (client == null) return null;

            _mapper.Map(request.Type, client);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update Client");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
