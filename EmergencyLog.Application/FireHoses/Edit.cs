using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Validators.FireSafetyHardwareValidators;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmergencyLog.Application.FireHoses
{
    public class EditCommandValidator : AbstractValidator<EditCommand<FireHose>>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Type).SetValidator(new FireHoseValidator());
        }
    }

    public class EditHandler : IRequestHandler<EditCommand<FireHose>, Result<Unit>>
    {
        private DataContext _context;
        private IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(EditCommand<FireHose> request, CancellationToken cancellationToken)
        {

            var fireHose = await _context.FireHoses.FindAsync(request.Type.Id);

            if (fireHose == null) return null;

            _mapper.Map(request.Type, fireHose);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update FireHose");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
