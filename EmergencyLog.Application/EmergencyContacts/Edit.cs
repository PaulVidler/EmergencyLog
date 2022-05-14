using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.EmergencyContacts
{
    public class EditCommandValidator : AbstractValidator<EditCommand<EmergencyContact>>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new EmergencyContactValidator());
        }
    }

    public class EditHandler : IRequestHandler<EditCommand<EmergencyContact>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<EmergencyContact> request, CancellationToken cancellationToken)
        {

            var emergencyContact = await _context.EmergencyContacts.FindAsync(request.Type.Id);

            if (emergencyContact == null) return null;

            _mapper.Map(request.Type, emergencyContact);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update emergencyContact");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
